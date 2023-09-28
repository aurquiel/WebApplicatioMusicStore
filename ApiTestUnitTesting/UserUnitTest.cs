using ApiTestUnitTesting.MockDependicies;
using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.UsesCases;
using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using WebApplicationMusicStore.DrivingAdapters.Utils;
using Xunit.Priority;

namespace ApiTestUnitTesting
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class UserUnitTest
    {
        private readonly UserController _userController;
        private readonly IMapper _mapper;

        public UserUnitTest()
        {
            _mapper = MapperTotalSingleton.GetMapper();
            _userController = new UserController(_mapper, 
                new UserUseCase(new UserPersistenceAdapter(new AudioStoreDbContext(), _mapper)));
        }

        [Fact, Priority(-6)]
        public async Task UserGetAll()
        {
            var result = await _userController.UserGetAll();

            Assert.True(result.Status);
            var usersDb = _mapper.Map<List<User>, List<UserDto>>(await GetUsersFronDb());
            Assert.Equal(result.Data, usersDb);
        }

        private async Task<List<User>> GetUsersFronDb()
        {
            using (AudioStoreDbContext db = new AudioStoreDbContext())
            {
                return _mapper.Map<List<UserEntity>, List<User>>(await db.UsersEntity.OrderBy(x => x.Alias).ToListAsync());
            }
        }

        [Fact, Priority(-5)]
        public async Task UserInsert()
        {
            var result = await _userController.UserInsert(new UserDto { Alias = "test", Password = "1234", Rol = "Store", StoreId = 3, CreationDateTime = DateTime.Now });

            Assert.True(result.Status);
        }

        private async Task<int> GetUserId(string alias, string password)
        {
            using(AudioStoreDbContext db = new AudioStoreDbContext())
            {
                return await db.UsersEntity.Where(x => x.Alias == alias && x.Password == Hash256.HashOfUserPassword(password)).Select(x => x.Id).FirstOrDefaultAsync();
            }
        }

        [Fact, Priority(-4)]
        public async Task UserUpdate()
        {
            var result = await _userController.UserUpdate(new UserDto { Id = await GetUserId("test", "1234"), Alias = "testUpdate", Password = "1234", Rol = "Store", StoreId = 3, CreationDateTime = DateTime.Now });

            Assert.True(result.Status);
        }

        [Fact, Priority(-3)]
        public async Task UserDelete()
        {
            var result = await _userController.UserDelete(await GetUserId("testUpdate", "1234"));

            Assert.True(result.Status);
        }
    }
}