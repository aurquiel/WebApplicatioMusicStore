using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters
{
    public class UserAccessPersistenceAdapter : IUserAccessPersistencePort
    {
        private readonly AudioStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserAccessPersistenceAdapter(AudioStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> AcccesLoginTokenAsync(string alias, string password)
        {
            var a = await _dbContext.UsersEntity.Where(x => x.Alias == alias && x.Password == password).FirstOrDefaultAsync();
            User user = _mapper.Map<User>(a);
            return user;
        }
    }
}
