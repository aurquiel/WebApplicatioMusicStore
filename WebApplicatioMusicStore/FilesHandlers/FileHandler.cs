using System.Text;
using System.Threading;

namespace WebApplicatioMusicStore.FilesHandlers
{
    public class FileHandler
    {
        IWebHostEnvironment _env;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public FileHandler(IWebHostEnvironment env)
        {
            this._env = env; 
        }

        public async Task<string> GetAudioListPlainText(string filePath)
        {
            try
            {
                await semaphore.WaitAsync();
                var plainText = string.Join(Environment.NewLine, await System.IO.File.ReadAllLinesAsync(filePath, Encoding.UTF8));
                semaphore.Release();
                return plainText;
            }
            catch 
            {
                semaphore.Release();
                throw;
            }
        }

        public async Task<(bool, string)> AudioSaverAsync(IFormFile file, string folderAudioPath, string fileOfSongs) 
        {
            try
            {
                await semaphore.WaitAsync();

                if (await SongAlreaadyExits($"{file.FileName}", fileOfSongs))
                {
                    return (false, "Error: Audio ya existen.");
                }

                string route = Path.Combine(_env.WebRootPath, folderAudioPath);

                if (!Directory.Exists(route))
                {
                    Directory.CreateDirectory(route);
                }

                string fileRoute = Path.Combine(route, $"{file.FileName}");

                using (FileStream fs = File.Create(fileRoute))
                {
                    await file.OpenReadStream().CopyToAsync(fs);
                }

                await WriteSongToFile($"{file.FileName}", fileOfSongs);
                
                semaphore.Release();

                return (true, "Extioso: Archivo de audio añadido.");
            }
            catch (Exception ex) 
            {
                semaphore.Release();
                throw;
            }
                
        }

        public async Task<(bool, string)> AudioDeleteAsync(string audioName, string folderAudioPath, string fileOfSongs)
        {
            try
            {
                await semaphore.WaitAsync();

                if (!await SongAlreaadyExits($"{audioName}", fileOfSongs))
                {
                    return (false, "Error: Audio no existe en la lista de reproduccion.");
                }

                string route = Path.Combine(_env.WebRootPath, folderAudioPath, audioName);

                if (!File.Exists(route))
                {
                    return (false, "Error: Audio no existe en la carpeta de reproduccion.");
                }

                File.Delete(route);

                string tempFile = Path.GetTempFileName();

                string routeFileOfSongs = Path.Combine(_env.WebRootPath, fileOfSongs);

                using (var sr = new StreamReader(routeFileOfSongs))
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

                File.Delete(routeFileOfSongs);
                File.Move(tempFile, routeFileOfSongs);

                semaphore.Release();

                return (true, "Extioso: Archivo de audio eliminado.");
            }
            catch 
            {
                semaphore.Release();
                throw;
            }
           
        }

        private async Task<bool> SongAlreaadyExits(string nameSong, string fileOfSongs)
        {
            string route = Path.Combine(_env.WebRootPath, fileOfSongs);
            string[] lines = await File.ReadAllLinesAsync(route, Encoding.UTF8);
            if(lines.Contains(nameSong))
            {
                return true;
            }

            return false;
        }

        private async Task<bool> WriteSongToFile(string nameSong, string fileOfSongs)
        {
            string route = Path.Combine(_env.WebRootPath, fileOfSongs);
            await File.AppendAllTextAsync(route, Environment.NewLine + nameSong, Encoding.UTF8);
            return true;    
        }

        public async Task<bool> SynchronizeAudioListAsync(List<string> listOfSongs, string fileListAudioPath, string folderAudioPath)
        {
            try
            {
                await semaphore.WaitAsync();

                string routeListOfSongs = Path.Combine(_env.WebRootPath, fileListAudioPath);
                string routeOfAudios = Path.Combine(_env.WebRootPath, folderAudioPath);

                await File.WriteAllTextAsync(routeListOfSongs, String.Join("\r\n", listOfSongs), Encoding.UTF8);

                foreach (var item in Directory.GetFiles(routeOfAudios))
                {
                    bool flag = false;
                    foreach (var song in listOfSongs)
                    {
                        if (Path.GetFileName(item) == song)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        File.Delete(item);
                    }
                }

                List<string> listOfSongsThatExist = new List<string>();
                foreach (var song in listOfSongs)
                {
                    foreach (var item in Directory.GetFiles(routeOfAudios))
                    {
                        if (Path.GetFileName(item) == song)
                        {
                            listOfSongsThatExist.Add(song);
                        }
                    }
                }

                await File.WriteAllTextAsync(routeListOfSongs, String.Join("\r\n", listOfSongsThatExist), Encoding.UTF8);

                semaphore.Release();

                return true;
            }
            catch 
            {
                semaphore.Release();
                throw;
            }
            
        }
    }
}
