using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SC2.DataAccess.FileStorage
{
    public class XmlStorageDataAccess : IStorageDataAccess
    {
        public void ProcessDirectory<T>(string targetDirectory, ref List<T> list)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.xml");
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

        public T ReadFromFile<T>(string path)
        {
            var fullPath = path.Contains(".xml") ? path : path + ".xml";

            var content = GetXmlString(fullPath);
            return Deserialize<T>(content);
        }

        public IEnumerable<string> GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path, "*.xml");
        }

        public void SaveToStorage<T>(T item, string storageFolder, string fileName)
        {
            var serializerObj = new XmlSerializer(typeof(T));

            using (var writeFileStream = new StreamWriter(storageFolder + fileName + ".xml"))
            {
                serializerObj.Serialize(writeFileStream, item);
            }
        }

        #region Common methods

        private static T Deserialize<T>(string xmlContent)
        {
            T result;

            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(xmlContent))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }

        private static string GetXmlString(string strFile)
        {
            string result;

            var xmlDoc = LoadXmlDocument(strFile);

            using (var writer = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(writer))
                {
                    xmlDoc.WriteTo(xmlWriter);
                    result = writer.ToString();
                }
            }

            return result;
        }

        private static XmlDocument LoadXmlDocument(string filePath)
        {
            var xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(filePath);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }

            return xmlDoc;
        }

        #endregion
    }
}
