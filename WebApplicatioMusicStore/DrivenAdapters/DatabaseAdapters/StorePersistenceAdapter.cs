using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters
{
    public class StorePersistenceAdapter : IStorePersistencePort
    {
        private AudioStoreDbContext _dbContext;
        private IMapper _mapper;

        public StorePersistenceAdapter(AudioStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return _mapper.Map<List<StoreEntity>, List<Store>>(await  _dbContext.StoresEntity.OrderBy(x => x.Code).ToListAsync());
        }

        public async Task<Store> GetAsync(int storeId)
        {
            return _mapper.Map<Store>(await _dbContext.StoresEntity.AsNoTracking().Where(x => x.Id == storeId).FirstOrDefaultAsync());
        }

        public async Task<Store> GetAsync(string storeCode)
        {
            return _mapper.Map<Store>(await _dbContext.StoresEntity.AsNoTracking().Where(x => x.Code == storeCode).FirstOrDefaultAsync());
        }

        public async Task InsertAsync(Store store)
        {
            await _dbContext.StoresEntity.AddAsync(_mapper.Map<StoreEntity>(store));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Store store)
        {
            _dbContext.Update(_mapper.Map<StoreEntity>(store));
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Store store)
        {
            _dbContext.Remove(_mapper.Map<StoreEntity>(store));
            await _dbContext.SaveChangesAsync();
        }
    }
}
