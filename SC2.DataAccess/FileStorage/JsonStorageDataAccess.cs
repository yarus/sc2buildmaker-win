using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SC2.DataAccess.FileStorage
{
    public class JsonStorageDataAccess : IStorageDataAccess
    {
        public void ProcessDirectory<T>(string targetDirectory, ref List<T> list)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.txt");

            foreach (string fileName in fileEntries)
            {
                list.Add(this.ReadFromFile<T>(fileName));
            }

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

            foreach (string subdirectory in subdirectoryEntries)
            {
                this.ProcessDirectory(subdirectory, ref list);
            }
        }

        public void SaveToStorage<T>(T item, string storageFolder, string fileName)
        {
            using (var writeFileStream = new StreamWriter(storageFolder + GetAdjustedFileName(fileName)))
            {
                var jsonWriter = new JsonTextWriter(writeFileStream);
                var ser = new JsonSerializer();
                ser.Serialize(jsonWriter, item);
                jsonWriter.Flush();
            }
        }

        public T ReadFromFile<T>(string path)
        {
            T result;

            using (var reader = new StreamReader(GetAdjustedFileName(path)))
            {
                var jsonReader = new JsonTextReader(reader);
                var ser = new JsonSerializer();
                result = ser.Deserialize<T>(jsonReader);
            }

            return result;
        }

        public IEnumerable<string> GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path, "*.txt");
        }

        private string GetAdjustedFileName(string fileName)
        {
            return fileName.Contains(".txt") ? fileName : fileName + ".txt";
        }
    }
}
