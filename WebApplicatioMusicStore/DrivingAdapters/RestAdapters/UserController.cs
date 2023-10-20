using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using WebApplicationMusicStore.DrivingAdapters.Utils;
using AutoMapper;
using ClassLibraryDomain.Ports.Driving;
using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserDriving _userDriving;

        public UserController(IMapper mapper, IUserDriving userDriving)
        {
            _mapper = mapper;
            _userDriving = userDriving;
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserGetAll")]
        public async Task<GeneralAnswerDto<List<UserDto>>> UserGetAll()
        {
            try
            {
                return new GeneralAnswerDto<List<UserDto>>(true, "Lista de Usuarios obtenida exitosamente.", _mapper.Map<List<User>, List<UserDto>>(await _userDriving.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<UserDto>>(false, "Error webservice obteniendo Lista de Usuarios, Excepcion: " + ex.Message, new List<UserDto>());
            }
        }


        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserInsert")]
        public async Task<GeneralAnswerDto<object>> UserInsert(UserDto userDTO)
        {
            try
            {
                userDTO.Password = Hash256.HashOfUserPassword(userDTO.Password);
                await _userDriving.InsertAsync(_mapper.Map<User>(userDTO));
                return new GeneralAnswerDto<object>(true, $"Usuario: {userDTO.Alias} creado exitosamente.", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice creando usuario: {userDTO.Alias}, Excepcion: " + ex.Message, new object());
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserUpdate")]
        public async Task<GeneralAnswerDto<object>> UserUpdate(UserDto userDTO)
        {
            try
            {
                userDTO.Password = Hash256.HashOfUserPassword(userDTO.Password);
                await _userDriving.UpdateAsync(_mapper.Map<User>(userDTO));
                return new GeneralAnswerDto<object>(true, $"Usuario: {userDTO.Alias} actualizado exitosamente.", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice actualziando usuario id: {userDTO.Id}, Excepcion: " + ex.Message, new object());
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserDelete/{userId}")]
        public async Task<GeneralAnswerDto<object>> UserDelete(int userId)
        {
            try
            {
                await _userDriving.DeleteAsync(userId);
                return new GeneralAnswerDto<object>(true, "Usuario eliminado exitosamente.", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice eliminando usuario id: {userId}, Excepcion: " + ex.Message, new object());
            }
        }
    }
}
