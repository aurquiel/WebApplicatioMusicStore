using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;


namespace ClassLibraryDomain.UsesCases
{
    public class AudioListUseCase : IAudioListDriving
    {
        private readonly IAudioListPersistencePort _audioListPersistencePort;

        public AudioListUseCase(IAudioListPersistencePort audioListPersistencePort)
        {
            _audioListPersistencePort = audioListPersistencePort;
        }

        public async Task CreateAudioListStore(string storeCode)
        {
            await _audioListPersistencePort.CreateAudioListStore(storeCode);
        }

        public async Task DeleteAudioListStore(string storeCode)
        {
            await _audioListPersistencePort.DeleteAudioListStoreAsync(storeCode);
        }

        public async Task<List<AudioFile>> GetAudioListStoreAsync(string storeCode)
        {
            return await _audioListPersistencePort.GetAudioListStoreAsync(storeCode);
        }

        public async Task RenameAudioListStoreFile(string oldFileName, string newFileName)
        {
            await _audioListPersistencePort.RenameAudioListStoreFile(oldFileName, newFileName); 
        }

        public async Task SynchronizeAudioListAllStoreAsync()
        {
            await _audioListPersistencePort.SynchronizeAudioListAllStoreAsync();    
        }

        public async Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, string storeCode)
        {
            await _audioListPersistencePort.SynchronizeAudioListStoreAsync(audioList, storeCode);
        }
    }
}
