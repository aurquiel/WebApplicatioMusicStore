using ClassLibraryDomain.Exceptions;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;

namespace WebApplicationMusicStore.DrivenAdapters.FileManager
{
    public class AudioPersistenceAdapter : FilesFunctionality, IAudioPersistencePort
    {
        private readonly IAudioFileDetails _audioFileDetails;

        public AudioPersistenceAdapter(IWebHostEnvironment env, IAudioFileDetails audioFileDetails) :base(env)
        {
            _audioFileDetails = audioFileDetails;
        }

        public async Task<List<AudioFile>> GetAudioListServerAsync()
        {
            try
            {
                await Semaphore.WaitAsync();
                List<AudioFile> audioFiles = new List<AudioFile>();
                var filesPath = Directory.GetFiles(FOLDER_AUDIO);
                foreach (var filePath in filesPath)
                {
                    var audioFile = _audioFileDetails.GetDetailsOfAudioFile(filePath);
                    if (audioFile != null)
                    {
                        audioFiles.Add(audioFile);
                    }
                }

                Semaphore.Release();
                return audioFiles;
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        public async Task AudioDeleteAsync(string audioName)
        {
            try
            {
                await Semaphore.WaitAsync();

                File.Delete(Path.Combine(FOLDER_AUDIO, audioName));

                Semaphore.Release();
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        public async Task<byte[]> AudiodGetBytesAsync(string audioName)
        {
            if (!SongAlreaadyExits(audioName))
            {
                throw new AudioNotFoundException(audioName);
            }

            return await File.ReadAllBytesAsync(FOLDER_AUDIO + audioName);
        }

        private bool SongAlreaadyExits(string nameSong)
        {
            return File.Exists(Path.Combine(FOLDER_AUDIO, nameSong));
        }

        public async Task AudioSaveAsync(string audioName, Stream file)
        {
            if (SongAlreaadyExits(audioName))
            {
                throw new AudioNotFoundException(audioName);
            }

            var dirSize = DirSize(new DirectoryInfo(FOLDER_AUDIO));
            if (dirSize + file.Length > MAX_SIZE_BYTES)
            {
                throw new AudioMaxCapacityException(MAX_SIZE_BYTES / (1024.0 * 1024.0));
            }

            string fileRoute = Path.Combine(FOLDER_AUDIO, $"{audioName}");

            using (FileStream fs = File.Create(fileRoute))
            {
                await file.CopyToAsync(fs);
                fs.Close();
            }
        }

        private long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
    }
}
