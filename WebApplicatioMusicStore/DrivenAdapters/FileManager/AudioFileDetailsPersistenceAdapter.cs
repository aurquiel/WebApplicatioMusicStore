using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using NAudio.Wave;

namespace WebApplicationMusicStore.DrivenAdapters.FileManager
{
    public class AudioFileDetailsPersistenceAdapter : IAudioFileDetails
    {
        public AudioFile GetDetailsOfAudioFile(string filePath)
        {
            try
            {
                return new AudioFile
                {
                    Name = Path.GetFileName(filePath),
                    Path = filePath,
                    Size = Math.Round(new FileInfo(filePath).Length / (1024.0 * 1024.0), 2),
                    Duration = StripMilliseconds(new AudioFileReader(filePath).TotalTime)
                };
            }
            catch
            {
                return new AudioFile
                {
                    Name = Path.GetFileName(filePath),
                    Path = filePath,
                    Size = Math.Round(new FileInfo(filePath).Length / (1024.0 * 1024.0), 2),
                    Duration = StripMilliseconds(new TimeSpan(0, 0, 0))
                };
            }
            
        }

        private TimeSpan StripMilliseconds(TimeSpan time)
        {
            return new TimeSpan(time.Days, time.Hours, time.Minutes, time.Seconds);
        }
    }
}
