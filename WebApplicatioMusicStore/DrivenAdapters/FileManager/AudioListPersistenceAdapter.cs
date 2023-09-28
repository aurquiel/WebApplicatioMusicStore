using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using System.Text;

namespace WebApplicationMusicStore.DrivenAdapters.FileManager
{
    public class AudioListPersistenceAdapter : FilesFunctionality, IAudioListPersistencePort
    {
        private readonly IAudioFileDetails _audioFileDetails;

        public AudioListPersistenceAdapter(IWebHostEnvironment env, IAudioFileDetails audioFileDetails) : base(env)
        {
            _audioFileDetails = audioFileDetails;
        }

        public async Task<List<AudioFile>> GetAudioListStoreAsync(string storeCode)
        {
            try
            {
                await Semaphore.WaitAsync();
                List<AudioFile> audioFiles = new List<AudioFile>();
                var fileNames = await System.IO.File.ReadAllLinesAsync(Path.Combine(FOLDER_AUDIO_LIST, "audioList" + storeCode + ".txt"), Encoding.UTF8);

                List<string> filesPath = new List<string>();
                foreach (var fileName in fileNames)
                {
                    filesPath.Add(Path.Combine(FOLDER_AUDIO, fileName));
                }

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

        public async Task SynchronizeAudioListAllStoreAsync()
        {
            try
            {
                await Semaphore.WaitAsync();

                foreach (var audioList in Directory.GetFiles(FOLDER_AUDIO_LIST))
                {
                    var lines = (await File.ReadAllLinesAsync(audioList, Encoding.UTF8)).ToList();
                    lines.RemoveAll(x => x == String.Empty);
                    List<string> listOfSongsThatExist = new List<string>();
                    var audios = Directory.GetFiles(FOLDER_AUDIO);

                    foreach (var line in lines)
                    {
                        foreach (var audio in audios)
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
                Semaphore.Release();
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        public async Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList, string storeCode)
        {
            try
            {
                await Semaphore.WaitAsync();
                string routeAudioList = Path.Combine(FOLDER_AUDIO_LIST, "audioList" + storeCode + ".txt");
                var itemFiles = Directory.GetFiles(FOLDER_AUDIO);

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
                Semaphore.Release();
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        public async Task CreateAudioListStore(string storeCode)
        {
            try
            {
                await Semaphore.WaitAsync();
                var s = File.CreateText(Path.Combine(FOLDER_AUDIO_LIST, "audioList" + storeCode + ".txt"));
                s.Close();
                Semaphore.Release();
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        public async Task DeleteAudioListStoreAsync(string storeCode)
        {
            try
            {
                await Semaphore.WaitAsync();
                File.Delete(Path.Combine(FOLDER_AUDIO_LIST, "audioList" + storeCode + ".txt"));
                Semaphore.Release();
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        public async Task RenameAudioListStoreFile(string oldStoreCode, string newStoreCode)
        {
            try
            {
                await Semaphore.WaitAsync();
                File.Move(Path.Combine(FOLDER_AUDIO_LIST, "audioList" + oldStoreCode + ".txt"), Path.Combine(FOLDER_AUDIO_LIST, "audioList" + newStoreCode + ".txt"));
                Semaphore.Release();
            }
            catch
            {
                Semaphore.Release();
                throw;
            }
        }

        
    }
}
