using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IAudioFileDetails
    {
        AudioFile GetDetailsOfAudioFile(string filePath);
    }
}
