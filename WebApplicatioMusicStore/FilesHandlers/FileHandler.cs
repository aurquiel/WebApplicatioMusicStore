using NAudio.Wave;
using System.Text;
using WebApplicationMusicStore.Models;

namespace WebApplicatioMusicStore.FilesHandlers
{
    public class FileHandler
    {
        public readonly string FOLDER_AUDIO;
        public readonly string FOLDER_AUDIO_LIST_STORE;
        public readonly long MAX_SIZE_BYTES = 524288000; //500 Mb

        IWebHostEnvironment _env;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public FileHandler(IWebHostEnvironment env)
        {
            this._env = env;
            FOLDER_AUDIO = Path.Combine(_env.ContentRootPath, $"App_Data\\audio\\");
            FOLDER_AUDIO_LIST_STORE = Path.Combine(_env.ContentRootPath, $"App_Data\\audioList\\");
        }

        public async Task<(bool, string)> AudioSaveAsync(IFormFile file)
        {
            if (SongAlreaadyExits($"{file.FileName}"))
            {
                return (false, "Error: Audio ya existen.");
            }

            var a = DirSize(new DirectoryInfo(FOLDER_AUDIO));
            if (a + file.Length > MAX_SIZE_BYTES)
            {
                return (false, "Error: Capacidad maxima de 500 Mb alcanzada, elimine archivos de audio para subir nuevos.");
            }

            string fileRoute = Path.Combine(FOLDER_AUDIO, $"{file.FileName}");

            using (FileStream fs = File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fs);
                fs.Close();
            }

            return (true, "Extioso: Archivo de audio añadido.");
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

        public async Task<byte[]> AudioDownloadGetBytesAsync(string audioName)
        {
            if (!SongAlreaadyExits(audioName))
            {
                throw new Exception($"Archivo de audio no existente, audio: {audioName}.");
            }

            return await File.ReadAllBytesAsync(FOLDER_AUDIO + audioName);
        }


        public async Task AudioDeleteAsync(string audioName)
        {
            try
            {
                await semaphore.WaitAsync();
                var audioListStoreFiles = Directory.GetFiles(FOLDER_AUDIO_LIST_STORE);

                File.Delete(Path.Combine(FOLDER_AUDIO, audioName));

                foreach (var audioList in Directory.GetFiles(FOLDER_AUDIO_LIST_STORE))
                {
                    var lines = (await File.ReadAllLinesAsync(audioList, Encoding.UTF8)).ToList();
                    lines.RemoveAll(x => x == String.Empty);
                    List<string> listOfSongsThatExist = new List<string>();
                    foreach (var audio in Directory.GetFiles(FOLDER_AUDIO))
                    {
                        foreach (var line in lines)
                        {
                            if (Path.GetFileName(audio) == line)
                            {
                                listOfSongsThatExist.Add(line);
                            }
                        }
                    }
                    string listOfAudioSynchronized = String.Join("\r\n", listOfSongsThatExist);
                    await File.WriteAllTextAsync(audioList, listOfAudioSynchronized, Encoding.UTF8);

                }

                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        private bool SongAlreaadyExits(string nameSong)
        {
            return File.Exists(Path.Combine(FOLDER_AUDIO, nameSong));
        }

        private AudioFile GetDetailsOfAudioFile(string filePath)
        {
            try
            {
                return new AudioFile
                {
                    Name = Path.GetFileName(filePath),
                    Path = filePath,
                    Size = new FileInfo(filePath).Length / (1024.0 * 1024.0),
                    Duration = StripMilliseconds(new AudioFileReader(filePath).TotalTime)
                };
            }
            catch
            {
                return null;
            }
        }

        private TimeSpan StripMilliseconds(TimeSpan time)
        {
            return new TimeSpan(time.Days, time.Hours, time.Minutes, time.Seconds);
        }

        public async Task<List<AudioFile>> GetAudioListAsync()
        {
            try
            {
                await semaphore.WaitAsync();
                List<AudioFile> audioFiles = new List<AudioFile>();
                var filesPath = Directory.GetFiles(FOLDER_AUDIO);
                foreach (var filePath in filesPath)
                {
                    var audioFile = GetDetailsOfAudioFile(filePath);
                    if (audioFile != null)
                    {
                        audioFiles.Add(audioFile);
                    }
                }

                semaphore.Release();
                return audioFiles;
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task<List<AudioFile>> GetAudioListStoreAsync(string storeCode)
        {
            try
            {
                await semaphore.WaitAsync();
                List<AudioFile> audioFiles = new List<AudioFile>();
                var fileNames = await System.IO.File.ReadAllLinesAsync(Path.Combine(FOLDER_AUDIO_LIST_STORE, "audioList" + storeCode + ".txt"), Encoding.UTF8);

                List<string> filesPath = new List<string>();
                foreach (var fileName in fileNames)
                {
                    filesPath.Add(Path.Combine(FOLDER_AUDIO, fileName));
                }

                foreach (var filePath in filesPath)
                {
                    var audioFile = GetDetailsOfAudioFile(filePath);
                    if (audioFile != null)
                    {
                        audioFiles.Add(audioFile);
                    }
                }

                semaphore.Release();
                return audioFiles;
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, string storeCode)
        {
            try
            {
                await semaphore.WaitAsync();
                string routeAudioList = Path.Combine(_env.WebRootPath, FOLDER_AUDIO_LIST_STORE + "audioList" + storeCode + ".txt");
                string routeOfAudios = Path.Combine(_env.WebRootPath, FOLDER_AUDIO);
                var itemFiles = Directory.GetFiles(routeOfAudios);

                List<AudioFile> listOfSongsThatExist = new List<AudioFile>();
                foreach (var song in audioList)
                {
                    foreach (var item in itemFiles)
                    {
                        if (Path.GetFileName(item) == song.Name)
                        {
                            listOfSongsThatExist.Add(song);
                        }
                    }
                }

                string listOfAudioSynchronized = String.Join(Environment.NewLine, listOfSongsThatExist.Select(x => x.Name).ToArray());
                await File.WriteAllTextAsync(routeAudioList, listOfAudioSynchronized, Encoding.UTF8);
                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task SynchronizeAudioListAllStoreAsync()
        {
            try
            {
                await semaphore.WaitAsync();

                foreach (var audioList in Directory.GetFiles(FOLDER_AUDIO_LIST_STORE))
                {
                    var lines = (await File.ReadAllLinesAsync(audioList, Encoding.UTF8)).ToList();    
                    lines.RemoveAll(x => x == String.Empty);
                    List<string> listOfSongsThatExist = new List<string>();
                    foreach (var audio in Directory.GetFiles(FOLDER_AUDIO))
                    {
                        foreach(var line in lines)
                        {
                            if (Path.GetFileName(audio) == line)
                            {
                                listOfSongsThatExist.Add(line);
                            }
                        }
                    }
                    string listOfAudioSynchronized = String.Join(Environment.NewLine, listOfSongsThatExist);
                    await File.WriteAllTextAsync(audioList, listOfAudioSynchronized, Encoding.UTF8);
                }
                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task RenameAudioListStoreFile(string oldFileName, string newFileName)
        {
            try
            {
                await semaphore.WaitAsync();
                File.Move(Path.Combine(FOLDER_AUDIO_LIST_STORE, oldFileName), Path.Combine(FOLDER_AUDIO_LIST_STORE, newFileName));
                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task CreateAudioListStore(string storeCode)
        {
            try
            {
                await semaphore.WaitAsync();
                var s = File.CreateText(Path.Combine(FOLDER_AUDIO_LIST_STORE, "audioList" + storeCode + ".txt"));
                s.Close();  
                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task DeleteAudioListStore(string storeCode)
        {
            try
            {
                await semaphore.WaitAsync();
                File.Delete(Path.Combine(FOLDER_AUDIO_LIST_STORE, "audioList" + storeCode + ".txt"));
                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }
    }
}
