using WebApplicatioMusicStore.Database;
using WebApplicatioMusicStore.Models;

namespace WebApplicatioMusicStore.Operations
{
    public interface IStoreOP
    {
        Task<List<Store>> GetAll();
        Task<GeneralAnswer<object>> Insert(Store store);
        Task<GeneralAnswer<string>> Update(Store store);
        Task<bool> Delete(Store store);
    }
}
