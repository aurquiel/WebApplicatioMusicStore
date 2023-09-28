using ClassLibraryDomain.Ports.Driving;
using ClassLibraryDomain.UsesCases;

namespace WebApplicationMusicStore.DrivingAdapters.Configuration
{
    public static class UseCaseConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IAudioListDriving, AudioListUseCase>();
            services.AddTransient<IAudioDriving, AudioUseCase>();
            services.AddTransient<IStoreDriving, StoreUseCase>();
            services.AddTransient<IRegisterDriving, RegisterUseCase>();
            services.AddTransient<IUserAccessDriving, UserAccessUseCase>();
            services.AddTransient<IUserDriving, UserUseCase>();

            return services;
        }
    }
}
