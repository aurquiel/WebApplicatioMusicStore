using ClassLibraryDomain.Exceptions;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;


namespace ClassLibraryDomain.UsesCases
{
    public class UserUseCase : IUserDriving
    {
        private readonly IUserPersistencePort _userPersistencePort;

        public UserUseCase(IUserPersistencePort userPersistencePort)
        {
            _userPersistencePort = userPersistencePort;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userPersistencePort.GetAllAsync();    
        }

        public async Task<User> GetAsync(int userId)
        {
            User user = await (_userPersistencePort.GetAsync(userId));
            
            if(user is null)
            {
                throw new UserNotFoundException(userId);
            }

            return user;
        }

        public async Task InsertAsync(User user)
        {
            await _userPersistencePort.InsertAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userPersistencePort.UpdateAsync(user);
        }

        public async Task DeleteAsync(int userId)
        {
            User user = await _userPersistencePort.GetAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            await _userPersistencePort.DeleteAsync(user);
        }
    }
}
