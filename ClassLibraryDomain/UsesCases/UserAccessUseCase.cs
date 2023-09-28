using ClassLibraryDomain.Exceptions;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.UsesCases
{
    public class UserAccessUseCase : IUserAccessDriving
    {
        private readonly IUserAccessPersistencePort _userAccessPersstencePort;

        public UserAccessUseCase(IUserAccessPersistencePort userAccessPeristencePort)
        {
            _userAccessPersstencePort = userAccessPeristencePort;
        }

        public async Task<User> AcccesLoginTokenAsync(string alias, string password)
        {
            User user = await _userAccessPersstencePort.AcccesLoginTokenAsync(alias, password);

            if(user is null)
            {
                throw new UserLoginException(user.Alias);
            }

            return user;
        }

    }
}
