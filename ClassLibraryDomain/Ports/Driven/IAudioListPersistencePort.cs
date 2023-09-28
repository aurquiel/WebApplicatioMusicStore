using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IAudioListPersistencePort
    {
        Task<List<AudioFile>> GetAudioListStoreAsync(string storeCode);
        Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, string storeCode);
        Task SynchronizeAudioListAllStoreAsync();
        Task RenameAudioListStoreFile(string oldStoreCode, string newStoreCode);
        Task CreateAudioListStore(string storeCode);
        Task DeleteAudioListStoreAsync(string storeCode);
    }
}
