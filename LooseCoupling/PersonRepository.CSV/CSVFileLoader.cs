using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonRepository.CSV
{
    public interface ICSVFileLoader
    {
        string LoadFile();
    }

    public class CSVFileLoader : ICSVFileLoader
    {
        private string filePath;

        public CSVFileLoader(string filePath)
        {
            this.filePath = filePath;
        }

        public string LoadFile()
        {
            using (var reader = new StreamReader(filePath))
            {
                string fileData = reader.ReadToEnd();
                return fileData;
            }
        }
    }
}
