using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public interface IRegisterOP
    {
        Task<List<Register>> GetRegisters(int storeId, DateTime dateInit, DateTime dateEnd);

        Task<bool> Insert(Register register);
    }
}
