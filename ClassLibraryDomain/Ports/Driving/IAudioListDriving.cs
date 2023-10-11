using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IAudioListDriving
    {
        Task<List<AudioFile>> GetAudioListStoreAsync(int storeId);
        Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, int storeId);
        Task SynchronizeAudioListAllStoreAsync();
        Task DeleteAudioListStore(int storeId);
        Task DeleteAudioFromAudioListStore(string audioName);
    }
}
