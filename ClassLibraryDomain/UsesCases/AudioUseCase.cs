using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.UsesCases
{
    public class AudioUseCase : IAudioDriving
    {
        private readonly IAudioPersistencePort _audioPersistencePort;

        public AudioUseCase(IAudioPersistencePort audioPersistencePort)
        {
            _audioPersistencePort = audioPersistencePort;
        }

        public async Task<List<AudioFile>> GetAudioListAsync()
        {
            return await _audioPersistencePort.GetAudioListAsync(); 
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
            await _audioPersistencePort.AudioDeleteAsync(audioName);
        }

        
    }
}
