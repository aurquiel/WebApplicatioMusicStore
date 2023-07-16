using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public class StoreOP : IStoreOP
    {
        private AudioStoreContext _db;

        public StoreOP(AudioStoreContext db)
        {
            _db = db;
        }

        public async Task<List<Store>> GetAll()
        {
            return await _db.Stores.ToListAsync();
        }

        public async Task<bool> Insert(Store store)
        {
            await _db.Stores.AddAsync(store);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Store store)
        {
            _db.Update(store);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Store store)
        {
            _db.Remove(store);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
