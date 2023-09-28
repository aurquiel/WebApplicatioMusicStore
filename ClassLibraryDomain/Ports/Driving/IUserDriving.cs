using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IUserDriving
    {
        Task<List<User>> GetAllAsync();
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);
    }
}
