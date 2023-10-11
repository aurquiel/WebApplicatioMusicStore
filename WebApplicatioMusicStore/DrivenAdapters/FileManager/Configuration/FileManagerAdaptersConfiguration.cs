using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters;

namespace WebApplicationMusicStore.DrivenAdapters.FileManager.Configuration
{
    public static class FileManagerAdaptersConfiguration
    {
        public static IServiceCollection AddFileManager(this IServiceCollection services)
        {
            services.AddSingleton<IAudioPersistencePort, AudioPersistenceAdapter>();
            services.AddTransient<IAudioFileDetails, AudioFileDetailsPersistenceAdapter>();

            return services;
        }
    }
}
