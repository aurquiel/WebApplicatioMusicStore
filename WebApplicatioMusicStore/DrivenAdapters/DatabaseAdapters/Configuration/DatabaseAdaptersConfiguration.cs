using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Configuration
{
    public static class DatabaseAdaptersConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<AudioStoreDbContext>(options => options.UseSqlServer(databaseConnection));
            services.AddTransient<IAudioListPersistencePort, AudioListPersistenceAdapter>();
            services.AddTransient<IStorePersistencePort, StorePersistenceAdapter>();
            services.AddTransient<IRegisterPersistencePort, RegisterPersistenceAdapter>();
            services.AddTransient<IUserAccessPersistencePort, UserAccessPersistenceAdapter>();
            services.AddTransient<IUserPersistencePort, UserPersistenceAdapter>();

            return services;
        }
    }
}
