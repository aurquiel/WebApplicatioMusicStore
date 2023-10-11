using AutoMapper;
using ClassLibraryDomain.Models;
using System.Linq.Expressions;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;

namespace ApiTestUnitTesting.MockDependicies
{
    internal class MapperTotalSingleton : Profile
    {
        private static IMapper _mapper;

        private MapperTotalSingleton()
        {
            CreateMap<AudioListEntity, AudioFile>();
            CreateMap<AudioFile, AudioListEntity>();
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
            CreateMap<StoreEntity, Store>();
            CreateMap<Store, StoreEntity>();
            CreateMap<RegisterEntity, Register>();
            CreateMap<Register, RegisterEntity>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<Store, StoreDto>();
            CreateMap<Register, RegisterDto>();
            CreateMap<RegisterDto, Register>();
            CreateMap<AudioFile, AudioFileDto>();
            CreateMap<AudioFileDto, AudioFile>();
        }

        public static IMapper GetMapper()
        {
            if (_mapper is null)
            {
                var mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperTotalSingleton()); //your automapperprofile 
                });
                _mapper = mockMapper.CreateMapper();
            }

            return _mapper;
        }
    }
}
