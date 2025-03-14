using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
        public interface IFileHandler
        {
            IEnumerable<string> ReadContent();
            void DeleteFiles();
        }
}