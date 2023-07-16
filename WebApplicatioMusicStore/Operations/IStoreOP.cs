using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public interface IStoreOP
    {
        Task<List<Store>> GetAll();
        Task<bool> Insert(Store store);
        Task<bool> Update(Store store);
        Task<bool> Delete(Store store);
    }
}
