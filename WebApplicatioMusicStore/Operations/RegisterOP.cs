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
            return await _db.Registers.Where(x => x.Id == storeId && x.CreationDateTime >= dateInit && x.CreationDateTime <= dateEnd).ToListAsync();
        }

        public async Task<bool> Insert(Register register)
        {
            await _db.Registers.AddAsync(register);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
