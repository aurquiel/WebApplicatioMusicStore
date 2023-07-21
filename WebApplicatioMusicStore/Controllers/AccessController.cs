using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.Database;
using WebApplicatioMusicStore.DTO;
using WebApplicatioMusicStore.Operations;
using WebApplicatioMusicStore.Utils;

namespace WebApplicatioMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserOP _userOP;

        public AccessController(IConfiguration configuration, IUserOP userOP)
        {
            this._configuration = configuration;
            this._userOP = userOP;
        }

        private string GenerateToken(UserDTO userDB)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDB.Alias),
                new Claim(ClaimTypes.Role, userDB.Rol)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<GeneralAnswer<UserAccessDTO>> UserLoginToken(UserLoginToken user)
        {
            try
            {
                user.Password = Hash256.HashOfUserPassword(user.Password);
                User userResult = await _userOP.AcccesLoginToken(user.Alias, user.Password);
                
                if (userResult != null)
                {
                    var userDB = UserDTO.FromDBToDTO(userResult);
                    var token = GenerateToken(userDB);

                    return new GeneralAnswer<UserAccessDTO>(true, "Exitoso: usuario y token obtenidos con exito.", new UserAccessDTO { User = userDB, Token = token });
                }
                else
                {
                    return new GeneralAnswer<UserAccessDTO>(false, "Error: usuario sin autorizacion.", new UserAccessDTO { User = new UserDTO(), Token = string.Empty });
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<UserAccessDTO>(false, "Error al obtener usuario y token, Excepcion: " + ex.Message, new UserAccessDTO { User = new UserDTO(), Token = string.Empty });
            }

        }
    }
}
