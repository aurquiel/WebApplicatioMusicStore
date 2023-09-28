using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IRegisterPersistencePort
    {
        Task<List<Register>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd);
        Task<List<Register>> GetByIdAndMonthAsync(int storeId, DateTime date);
        Task InsertAsync(List<Register> registers);
        Task DeleteAllByStoreIdAsync(int storeId);
    }
}
