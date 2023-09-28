using AutoMapper;
using ClassLibraryDomain.Models;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos.Mappings
{
    public class AudioStoreRestMappingProfile : Profile
    {
        public AudioStoreRestMappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<Store, StoreDto>();
            CreateMap<Register, RegisterDto>();
            CreateMap<RegisterDto, Register>();
            CreateMap<AudioFile, AudioFileDto>();
            CreateMap<AudioFileDto, AudioFile>();
        }
    } 
}
