using AutoMapper;
using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities.Mappings
{
    public class AudioStoreDbMappingProfile : Profile
    {
        public AudioStoreDbMappingProfile()
        {
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
            CreateMap<StoreEntity, Store>();
            CreateMap<Store, StoreEntity>();
            CreateMap<RegisterEntity, Register>();
            CreateMap<Register, RegisterEntity>();
        }
    }
}
