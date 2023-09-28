using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IUserAccessPersistencePort
    {
        Task<User> AcccesLoginTokenAsync(string alias, string password);
    }
}
