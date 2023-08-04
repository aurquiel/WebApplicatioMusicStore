using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplicatioMusicStore.Database;
using WebApplicatioMusicStore.Models;

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
            return await _db.Stores.OrderBy(x => x.Code).ToListAsync();
        }

        public async Task<GeneralAnswer<object>> Insert(Store store)
        {
            if(_db.Stores.Any(x => x.Code == store.Code)) 
            {
                return new GeneralAnswer<object>(false, "Error codigo de tienda ya existente en la base de datos", null);
            }
            await _db.Stores.AddAsync(store);
            var result = await _db.SaveChangesAsync() > 0;
            if(result)
            {
                return new GeneralAnswer<object>(true, "Teinda creada en la base de datos con exito.", null);
            }

            return new GeneralAnswer<object>(false, "Error al crear tienda en la base de datos.", null);
        }

        public async Task<GeneralAnswer<string>> Update(Store store)
        {
            if (_db.Stores.Any(x => x.Code == store.Code && x.Id != store.Id))
            {
                return new GeneralAnswer<string>(false, $"Error ya existe una tienda con el codigo {store.Code}", null);
            }
            string oldCodeString = _db.Stores.Where(x => x.Id == store.Id).Select(x => x.Code).FirstOrDefault();
            _db.Update(store);
            var result = await _db.SaveChangesAsync() > 0;

            if (result)
            {
                return new GeneralAnswer<string>(true, "Tienda actulizada en la base de datos.", oldCodeString);    
            }

            return new GeneralAnswer<string>(false, "Error actulizar tienda en la base de datos.", null); ;
        }

        public async Task<bool> Delete(Store store)
        {
            _db.Remove(store);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
