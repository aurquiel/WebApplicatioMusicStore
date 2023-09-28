using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters
{
    public class UserPersistenceAdapter : IUserPersistencePort
    {
        private readonly AudioStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserPersistenceAdapter(AudioStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var list = await _dbContext.UsersEntity.OrderBy(x => x.Alias).ToListAsync();
            list.ForEach(x => x.Password = String.Empty);
            return _mapper.Map<List<UserEntity>, List<User>>(list);
        }

        public async Task<User> GetAsync(int userId)
        {
            return _mapper.Map<User>(await _dbContext.UsersEntity.AsNoTracking().Where(x => x.Id == userId).FirstOrDefaultAsync());
        }

        public async Task InsertAsync(User user)
        {
            await _dbContext.UsersEntity.AddAsync(_mapper.Map<UserEntity>(user));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Update(_mapper.Map<UserEntity>(user));
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _dbContext.Remove(_mapper.Map<UserEntity>(user));
            await _dbContext.SaveChangesAsync();
        }
    }
}
