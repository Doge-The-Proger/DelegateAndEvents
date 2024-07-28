using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDeligateAndEventTask
{
    public class FileArgs : EventArgs
    {
        public string Directory { get;}

        public string FileName { get; }

        public FileArgs (string directory, string fileName)
        {
            Directory = directory; 
            FileName = fileName;
        }
    }
}
