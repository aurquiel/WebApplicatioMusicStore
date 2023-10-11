namespace WebApplicationMusicStore.DrivenAdapters.FileManager
{
    public class FilesFunctionality
    {
        protected readonly string FOLDER_AUDIO;
        protected readonly long MAX_SIZE_BYTES = 734003200; //700 Mb
        protected static SemaphoreSlim Semaphore = new SemaphoreSlim(1);

        private IWebHostEnvironment _env;

        public FilesFunctionality(IWebHostEnvironment env)
        {
            this._env = env;
            FOLDER_AUDIO = Path.Combine(_env.ContentRootPath, $"App_Data\\audio\\");
        }
    }
}
