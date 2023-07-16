using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.Operations
{
    public interface IUserOP
    {
        Task<User> Get(int usr_id);
        Task<List<User>> GetAll();
        Task<bool> Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
        Task<User> AcccesLoginToken(string usr_alias, string usr_password);
    }
}
