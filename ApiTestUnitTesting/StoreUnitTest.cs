using ApiTestUnitTesting.MockDependicies;
using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.UsesCases;
using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;
using WebApplicationMusicStore.DrivenAdapters.FileManager;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using Xunit.Priority;

namespace ApiTestUnitTesting
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class StoreUnitTest
    {
        private readonly StoreController _storeController;
        private IMapper _mapper;

        public StoreUnitTest()
        {
            _mapper = MapperTotalSingleton.GetMapper();
            _storeController = new StoreController( _mapper,
                new StoreUseCase(new StorePersistenceAdapter(new AudioStoreDbContext(), _mapper), new AudioListPersistenceAdapter(new WebHostEnvironmentDummy(), new AudioFileDetailsPersistenceAdapter()) ));
        }

        [Fact, Priority(-6)]
        public async Task StoreGetAll()
        {
            var result = await _storeController.StoreGetAll();

            Assert.True(result.Status);
            var listDb = _mapper.Map<List<Store>, List<StoreDto>>(await GetStoresFromDb());
            Assert.Equal(result.Data, listDb);
        }

        private async Task<List<Store>> GetStoresFromDb()
        {
            using(AudioStoreDbContext _dbContext = new AudioStoreDbContext())
            {
                return _mapper.Map<List<StoreEntity>, List<Store>>(await _dbContext.StoresEntity.OrderBy(x => x.Code).ToListAsync());
            }
        }

        [Fact, Priority(-6)]
        public async Task StoreInsert()
        {
            var result = await _storeController.StoreInsert(new StoreDto { Code = "9999", CreationDateTime = DateTime.Now  });

            Assert.True(result.Status);
            Assert.True(File.Exists(Path.Combine(new WebHostEnvironmentDummy().ContentRootPath, "App_Data\\audioList\\audioList9999.txt")));
        }

        [Fact, Priority(-5)]
        public async Task StoreInsertAlreadyExists()
        {
            var result2 = await _storeController.StoreInsert(new StoreDto { Code = "9999", CreationDateTime = DateTime.Now });
            Assert.False(result2.Status);
        }

        [Fact, Priority(-4)]
        public async Task StoreUpdate()
        {
            var result = await _storeController.StoreUpdate(new StoreDto { Id = await GetStoreIdByCode("9999"), Code = "9900", CreationDateTime = DateTime.Now });

            Assert.True(result.Status);
            Assert.False(File.Exists(Path.Combine(new WebHostEnvironmentDummy().ContentRootPath, "App_Data\\audioList\\audioList9999.txt")));
            Assert.True(File.Exists(Path.Combine(new WebHostEnvironmentDummy().ContentRootPath, "App_Data\\audioList\\audioList9900.txt")));

        }

        private async Task<int> GetStoreIdByCode(string code)
        {
            using(AudioStoreDbContext db = new AudioStoreDbContext()) 
            {
                return await db.StoresEntity.Where(x => x.Code == code).Select(x => x.Id).FirstOrDefaultAsync();
            }
        }

        [Fact, Priority(-3)]
        public async Task StoreDelete()
        {
            var result = await _storeController.StoreDelete(await GetStoreIdByCode("9900"));

            Assert.True(result.Status);
            Assert.False(File.Exists(Path.Combine(new WebHostEnvironmentDummy().ContentRootPath, "App_Data\\audioList\\audioList9900.txt")));
        }

    }
}