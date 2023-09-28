using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters
{
    public class RegisterPersistenceAdapter : IRegisterPersistencePort
    {
        private AudioStoreDbContext _dbContext;
        private IMapper _mapper;

        public RegisterPersistenceAdapter(AudioStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Register>> GetByIdAndMonthAsync(int storeId, DateTime date)
        {
            return _mapper.Map<List<RegisterEntity>, List<Register>>(await _dbContext.RegistersEntity.Where(x => x.StoreId == storeId && x.CreationDateTime.Date.Month == date.Month && x.CreationDateTime.Date.Year == date.Year).ToListAsync());
        }

        public async Task<List<Register>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            return _mapper.Map<List<RegisterEntity>, List<Register>>(await _dbContext.RegistersEntity.Where(x => x.StoreId == storeId && x.CreationDateTime.Date >= dateInit.Date && x.CreationDateTime.Date <= dateEnd.Date).ToListAsync());
        }

        public async Task InsertAsync(List<Register> registers)
        {
            await _dbContext.RegistersEntity.AddRangeAsync(_mapper.Map<List<Register>, List<RegisterEntity>>(registers));
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllByStoreIdAsync(int storeId)
        {
            var list = await _dbContext.RegistersEntity.Where(x => x.StoreId == storeId).ToListAsync();
            _dbContext.RegistersEntity.RemoveRange(list);
            await _dbContext.SaveChangesAsync();
        }
    }
}
