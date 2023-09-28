using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IAudioPersistencePort
    {
        Task AudioSaveAsync(string audioName, Stream streamFile);
        Task<byte[]> AudiodGetBytesAsync(string audioName);
        Task AudioDeleteAsync(string audioName);
        Task<List<AudioFile>> GetAudioListAsync();
    }
}
