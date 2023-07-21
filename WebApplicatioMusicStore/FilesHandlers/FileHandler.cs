using System.Text;

namespace WebApplicatioMusicStore.FilesHandlers
{
    public class FileHandler
    {
        public readonly string FOLDER_AUDIO;
        public readonly string FOLDER_AUDIO_LIST_STORE;

        IWebHostEnvironment _env;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public FileHandler(IWebHostEnvironment env)
        {
            this._env = env;
            FOLDER_AUDIO = Path.Combine(_env.WebRootPath, $"assets\\audio\\");
            FOLDER_AUDIO_LIST_STORE = Path.Combine(_env.WebRootPath, $"assets\\audioList\\");
        }

        public async Task<(bool, string)> AudioSaveAsync(IFormFile file)
        {
            if (await SongAlreaadyExits($"{file.FileName}"))
            {
                return (false, "Error: Audio ya existen.");
            }

            string fileRoute = Path.Combine(FOLDER_AUDIO, $"{file.FileName}");

            using (FileStream fs = File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fs);
            }

            return (true, "Extioso: Archivo de audio añadido.");
        }

        public async Task<byte[]> AudioDownloadGetBytesAsync(string audioName)
        {
            if (!await SongAlreaadyExits(audioName))
            {
                throw new Exception($"Archivo de audio no existente, audio: {audioName}.");
            }

            return await File.ReadAllBytesAsync(FOLDER_AUDIO + audioName);
        }


        public async Task AudioDeleteAsync(List<string> audioNamesList)
        {
            try
            {
                await semaphore.WaitAsync();
                var audioListStoreFiles = Directory.GetFiles(FOLDER_AUDIO_LIST_STORE);

                foreach (var audioName in audioNamesList)
                {
                    File.Delete(Path.Combine(FOLDER_AUDIO, audioName));

                    foreach (var audioListStore in audioListStoreFiles)
                    {
                        string tempFile = Path.GetTempFileName();

                        using (var sr = new StreamReader(audioListStore))
                        using (var sw = new StreamWriter(tempFile))
                        {
                            string line;

                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line != audioName)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }

                        File.Delete(audioListStore);
                        File.Move(tempFile, audioListStore);
                    }
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
            string route = Path.Combine(_env.WebRootPath, FOLDER_AUDIO);
            string[] lines = await File.ReadAllLinesAsync(route, Encoding.UTF8);
            if (lines.Contains(nameSong))
            {
                return true;
            }

            return false;
        }

        public async Task<string> GetAudioListAsync()
        {
            return await Task.Run(() => String.Join("\r\n", Directory.GetFiles(FOLDER_AUDIO)));
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

        public async Task SynchronizeAudioListStoreAsync(string audioList, string storeCode)
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

                await File.WriteAllTextAsync(routeAudioList, String.Join("\r\n", listOfSongsThatExist), Encoding.UTF8);
                semaphore.Release();
            }
            catch
            {
                semaphore.Release();
                throw;
            }
        }

        public void RenameAudioListStoreFile(string oldFileName, string newFileName)
        {
            File.Move(Path.Combine(FOLDER_AUDIO_LIST_STORE, oldFileName), Path.Combine(FOLDER_AUDIO_LIST_STORE, newFileName)); 
        }
    }
}
