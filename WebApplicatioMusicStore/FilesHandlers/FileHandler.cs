using System.Text;

namespace WebApplicatioMusicStore.FilesHandlers
{
    public class FileHandler
    {
        public readonly string FOLDER_AUDIO;
        public readonly string FOLDER_AUDIO_LIST_STORE;
        public readonly long MAX_SIZE_BYTES = 500000000; //500 Mb

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
            if (await SongAlreaadyExits($"{file.FileName}"))
            {
                return (false, "Error: Audio ya existen.");
            }

            if(DirSize(new DirectoryInfo(FOLDER_AUDIO)) + file.Length > MAX_SIZE_BYTES)
            {
                return (false, "Error: Capacidad maxima de 500 Mb alcanzada, elimine archivos de audio para subir nuevos.");
            }

            string fileRoute = Path.Combine(FOLDER_AUDIO, $"{file.FileName}");

            using (FileStream fs = File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fs);
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
            if (!await SongAlreaadyExits(audioName))
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

        private async Task<bool> SongAlreaadyExits(string nameSong)
        {
            var audios = Directory.GetFiles(FOLDER_AUDIO).Select(x => Path.GetFileName(x)).ToList();
            if (audios.Contains(nameSong))
            {
                return true;
            }

            return false;
        }

        public async Task<string> GetAudioListAsync()
        {
            return await Task.Run(() => String.Join("\r\n", Directory.GetFiles(FOLDER_AUDIO).Select(x => Path.GetFileName(x))));
        }

        public async Task<string> GetAudioListStoreAsync(string storeCode)
        {
            try
            {
                await semaphore.WaitAsync();
                var audioList = string.Join(Environment.NewLine, await System.IO.File.ReadAllLinesAsync(Path.Combine(FOLDER_AUDIO_LIST_STORE,"audioList" + storeCode + ".txt"), Encoding.UTF8));
                semaphore.Release();
                return audioList;
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task<string> SynchronizeAudioListStoreAsync(string audioList, string storeCode)
        {
            try
            {
                await semaphore.WaitAsync();
                var audioListArray = audioList.Split(Environment.NewLine).ToList();
                string routeAudioList = Path.Combine(_env.WebRootPath, FOLDER_AUDIO_LIST_STORE + "audioList" + storeCode + ".txt");
                string routeOfAudios = Path.Combine(_env.WebRootPath, FOLDER_AUDIO);

                List<string> listOfSongsThatExist = new List<string>();
                foreach (var song in audioListArray)
                {
                    foreach (var item in Directory.GetFiles(routeOfAudios))
                    {
                        if (Path.GetFileName(item) == song)
                        {
                            listOfSongsThatExist.Add(song);
                        }
                    }
                }

                string listOfAudioSynchronized = String.Join("\r\n", listOfSongsThatExist);
                await File.WriteAllTextAsync(routeAudioList, listOfAudioSynchronized , Encoding.UTF8);
                semaphore.Release();
                return listOfAudioSynchronized;
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
