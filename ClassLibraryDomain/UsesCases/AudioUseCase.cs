using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;

namespace ClassLibraryDomain.UsesCases
{
    public class AudioUseCase : IAudioDriving
    {
        private readonly IAudioPersistencePort _audioPersistencePort;
        private readonly IAudioListPersistencePort _audioListPersistencePort;

        public AudioUseCase(IAudioPersistencePort audioPersistencePort, IAudioListPersistencePort audioListPersistencePort)
        {
            _audioPersistencePort = audioPersistencePort;
            _audioListPersistencePort = audioListPersistencePort;
        }

        public async Task<List<AudioFile>> GetAudioListAsync()
        {
            return await _audioPersistencePort.GetAudioListServerAsync(); 
        }

        public async Task<byte[]> AudiodGetBytesAsync(string audioName)
        {
            return await _audioPersistencePort.AudiodGetBytesAsync(audioName);
        }

        public async Task AudioSaveAsync(string audioName, Stream streamFile)
        {
            await _audioPersistencePort.AudioSaveAsync(audioName, streamFile);
        }

        public async Task AudioDeleteAsync(string audioName)
        {
            await _audioPersistencePort.AudioDeleteAsync(audioName); //Eliminar de la carpeta fisica
            await _audioListPersistencePort.DeleteAudioFromAudioListStoreAsync(audioName); //Eliminar de las lista de audio de las tiendas.
        }
    }
}
