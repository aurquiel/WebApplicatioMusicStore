using ClassLibraryDomain.Models;
using System.Runtime.ConstrainedExecution;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IUserPersistencePort
    {
        Task<User> GetAsync(int userId);
        Task<List<User>> GetAllAsync();
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
