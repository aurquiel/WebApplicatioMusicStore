using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using WebApplicationMusicStore.DrivingAdapters.Utils;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserAccessDriving _userAccessDriving;

        public AccessController(IConfiguration configuration, IMapper mapper, IUserAccessDriving userAccessDriving)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userAccessDriving = userAccessDriving;
        }

        [AllowAnonymous]
        [HttpGet("{alias}/{password}")]
        public async Task<GeneralAnswerDto<UserAccessDto>> UserLoginToken(string alias, string password)
        {
            try
            {
                password = Hash256.HashOfUserPassword(password);
                User user = await _userAccessDriving.AcccesLoginTokenAsync(alias, password);
                var token = GenerateToken(user);

                return new GeneralAnswerDto<UserAccessDto>(true, $"Usuario logueado con exito, user: {alias}", new UserAccessDto { User = _mapper.Map<UserDto>(user), Token = token });
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<UserAccessDto>(false, $"Error websrevice login usuario: {alias}, Exception: " + ex.Message, new UserAccessDto { User = new UserDto(), Token = string.Empty });
            }

        }

        private string GenerateToken(User userDB)
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
    }
}
