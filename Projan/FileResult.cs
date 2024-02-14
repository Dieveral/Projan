using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projan
{
    internal class FileResult
    {
        public string FilePath { get; set; }
        public string Namespace { get; set; }
        public string Class { get; set; }

        public Dictionary<string, int> Words { get; set; }

        public FileResult(string filePath)
        {
            FilePath = filePath;
            Namespace = string.Empty;
            Class = string.Empty;
            Words = new Dictionary<string, int>();
        }
    }
}
