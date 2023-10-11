using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IAudioListPersistencePort
    {
        Task<List<AudioFile>> GetAudioListStoreAsync(int storeId);
        Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList);
        Task SynchronizeAudioListAllStoreAsync(List<AudioFile> audioList);
        Task DeleteAudioListStoreAsync(int storeId);
        Task DeleteAudioFromAudioListStoreAsync(string audioName);
    }
}
