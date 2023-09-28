using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IAudioDriving
    {
        Task AudioSaveAsync(string audioName, Stream streamFile);
        Task<byte[]> AudiodGetBytesAsync(string audioName);
        Task AudioDeleteAsync(string audioName);
        Task<List<AudioFile>> GetAudioListAsync();
    }
}
