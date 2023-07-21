using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.Database;
using WebApplicatioMusicStore.DTO;
using WebApplicatioMusicStore.Operations;
using WebApplicatioMusicStore.Utils;
using Microsoft.AspNetCore.Identity;

namespace WebApplicatioMusicStore.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserOP _userOP;

        public UserController(IUserOP userOP)
        {
            this._userOP = userOP;
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserGetAll")]
        public async Task<GeneralAnswer<List<UserDTO>>> UserGetAll()
        {
            try
            {
                return new GeneralAnswer<List<UserDTO>>(true, "Exitoso: Usuarios obtenidos.", UserDTO.FromDBToDTO(await _userOP.GetAll()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<UserDTO>>(false, "Error obteniendo Usuarios, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserInsert")]
        public async Task<GeneralAnswer<object>> UserInsert(UserDTO userDTO)
        {
            try
            {
                userDTO.Password = Hash256.HashOfUserPassword(userDTO.Password);
                if (await _userOP.Insert(UserDTO.FromDTOToDB(userDTO)))
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Usuario creado.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(false, "Error al crear usuario.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error creando Usuario, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserUpdate")]
        public async Task<GeneralAnswer<object>> UserUpdate(UserDTO userDTO)
        {
            try
            {
                userDTO.Password = Hash256.HashOfUserPassword(userDTO.Password);

                if (await _userOP.Update(UserDTO.FromDTOToDB(userDTO)))
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Usuario editado.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(false, "Error al editar usuario.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error editando Usuario, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserDelete")]
        public async Task<GeneralAnswer<object>> UserDelete(UserDTO userDTO)
        {
            try
            {
                if (await _userOP.Delete(UserDTO.FromDTOToDB(userDTO)))
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Usuario eliminado.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(false, "Error al eliminar usuario.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error eliminando Usuario, Excepcion webservice:" + ex.Message, null);
            }
        }
    }
}
