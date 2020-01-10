using System.Collections.Generic;

namespace SC2.DataAccess.FileStorage
{
    public interface IStorageDataAccess
    {
        void ProcessDirectory<T>(string targetDirectory, ref List<T> list);

        void SaveToStorage<T>(T item, string storageFolder, string fileName);

        T ReadFromFile<T>(string path);

        IEnumerable<string> GetFileNamesInDirectory(string path);
    }
}
