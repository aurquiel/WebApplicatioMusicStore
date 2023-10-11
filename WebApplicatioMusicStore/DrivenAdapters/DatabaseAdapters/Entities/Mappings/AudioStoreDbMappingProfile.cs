using AutoMapper;
using ClassLibraryDomain.Models;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities.Mappings
{
    public class AudioStoreDbMappingProfile : Profile
    {
        public AudioStoreDbMappingProfile()
        {
            CreateMap<AudioListEntity, AudioFile>();
            CreateMap<AudioFile, AudioListEntity>();
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
            CreateMap<StoreEntity, Store>();
            CreateMap<Store, StoreEntity>();
            CreateMap<RegisterEntity, Register>();
            CreateMap<Register, RegisterEntity>();
        }
    }
}
