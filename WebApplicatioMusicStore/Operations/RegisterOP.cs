using Microsoft.EntityFrameworkCore;
using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public class RegisterOP : IRegisterOP
    {
        private AudioStoreContext _db;

        public RegisterOP(AudioStoreContext db)
        {
            _db = db;
        }

        public async Task<List<Register>> GetRegisters(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            return await _db.Registers.Where(x => x.Id == storeId && x.CreationDateTime.Date >= dateInit && x.CreationDateTime.Date <= dateEnd).ToListAsync();
        }

        public async Task<List<Register>> GetRegistersByDate(DateTime date)
        {
            return await _db.Registers.Where(x => x.CreationDateTime.Date == date).ToListAsync();
        }

        public async Task<bool> Insert(Register register)
        {
            await _db.Registers.AddAsync(register);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAllUserId(int userId)
        {
            var list  = await _db.Registers.Where(x => x.UserId == userId).ToListAsync();
            _db.Registers.RemoveRange(list);
            return await _db.SaveChangesAsync() > 0;
        }

    }
}
