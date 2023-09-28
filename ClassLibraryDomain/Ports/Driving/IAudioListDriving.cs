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
        Task<List<AudioFile>> GetAudioListStoreAsync(string storeCode);
        Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, string storeCode);
        Task SynchronizeAudioListAllStoreAsync();
        Task RenameAudioListStoreFile(string oldFileName, string newFileName);
        Task CreateAudioListStore(string storeCode);
        Task DeleteAudioListStore(string storeCode);
    }
}
