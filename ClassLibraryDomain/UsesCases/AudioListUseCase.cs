using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;

namespace ClassLibraryDomain.UsesCases
{
    public class AudioListUseCase : IAudioListDriving
    {
        private readonly IAudioListPersistencePort _audioListPersistencePort;
        private readonly IAudioPersistencePort _audioPersistencePort;

        public AudioListUseCase(IAudioListPersistencePort audioListPersistencePort, IAudioPersistencePort audioPersistencePort)
        {
            _audioListPersistencePort = audioListPersistencePort;
            _audioPersistencePort = audioPersistencePort;
        }

        public async Task<List<AudioFile>> GetAudioListStoreAsync(int storeId)
        {
            return await _audioListPersistencePort.GetAudioListStoreAsync(storeId);
        }

        public async Task SynchronizeAudioListAllStoreAsync()
        {
            List<AudioFile> audioListServer = await _audioPersistencePort.GetAudioListServerAsync();
            await _audioListPersistencePort.SynchronizeAudioListAllStoreAsync(audioListServer);
        }

        public async Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, int storeId)
        {
            await _audioListPersistencePort.DeleteAudioListStoreAsync(storeId);
            await _audioListPersistencePort.SynchronizeAudioListStoreAsync(audioList);
        }

        public async Task DeleteAudioListStore(int storeId)
        {
            await _audioListPersistencePort.DeleteAudioListStoreAsync(storeId);
        }

        public async Task DeleteAudioFromAudioListStore(string audioName)
        {
            await _audioListPersistencePort.DeleteAudioFromAudioListStoreAsync(audioName);  
        }
    }
}
