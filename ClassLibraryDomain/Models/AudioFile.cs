using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Models
{
    public class AudioFile
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public TimeSpan Duration { get; set; }

        public double Size { get; set; }
    }
}
