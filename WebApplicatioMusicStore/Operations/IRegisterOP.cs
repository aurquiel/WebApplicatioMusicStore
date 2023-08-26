using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public interface IRegisterOP
    {
        Task<List<Register>> GetRegisters(int storeId, DateTime dateInit, DateTime dateEnd);
        Task<List<Register>> GetRegistersByMonth(int storeid,DateTime date);

        Task<bool> Insert(Register register);
        Task<bool> DeleteAllStoreId(int storeId);
    }
}
