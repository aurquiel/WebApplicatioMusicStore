using Microsoft.EntityFrameworkCore;
using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public class UserOP : IUserOP
    {
        private AudioStoreContext _db;

        public UserOP(AudioStoreContext db)
        {
            this._db = db;
        }

        public async Task<User> AcccesLoginToken(string alias, string password)
        {
            var user = await _db.Users.Where(u => u.Alias == alias && u.Password == password).FirstOrDefaultAsync();
            if(user != null)
            {
                user.Password = String.Empty;
            }
            return user;
        }
        
        public async Task<User> Get(int usrId)
        {
            return await _db.Users.FirstOrDefaultAsync(x =>  x.Id == usrId); 
        }

        public async Task<List<User>> GetAll()
        {
            var list = await _db.Users.ToListAsync();
            list.ForEach(x => x.Password = String.Empty);
            return list;
        }

        public async Task<bool> Insert(User user)
        {
            await _db.Users.AddAsync(user);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(User user)
        {
            _db.Update(user);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(User user)
        {
            _db.Remove(user);
            return await _db.SaveChangesAsync() > 0;
        }

    }
}
