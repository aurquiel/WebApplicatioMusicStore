using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IStorePersistencePort
    {
        Task<List<Store>> GetAllAsync();
        Task<Store> GetAsync(int storeId);
        Task<Store> GetAsync(string storeCode);
        Task InsertAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(Store store);
    }
}
