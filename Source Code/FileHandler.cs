using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    public class FileHandler : IFileHandler
    {
        private readonly string _filePath;

        public FileHandler(IConfiguration configuration)
        {
            _filePath = configuration["Folderi"];
        }
        public void DeleteFiles()
        {
            foreach (var item in Directory.EnumerateFiles(_filePath))
            { 
                File.Delete(item);
            }
        }

        public IEnumerable<string> ReadContent()
        {
            foreach (var item in Directory.EnumerateFiles(_filePath)) 
            {
                yield return File.ReadAllText(item);

            }
        }
    }
}
