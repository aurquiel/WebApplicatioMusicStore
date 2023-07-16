using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicatioMusicStore.DTO;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.Operations;

namespace WebApplicatioMusicStore.Controllers
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IRegisterOP _registerOP;

        public RegisterController(IRegisterOP registerOP)
        {
            this._registerOP = registerOP;
        }

        [HttpPost(), Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/RegisterInsert")]
        public async Task<GeneralAnswer> RegisterInsert(RegisterDTO registerDTO)
        {
            try
            {
                if (await _registerOP.Insert(RegisterDTO.FromDTOToDB(registerDTO)))
                {
                    return new GeneralAnswer(true, "Exitoso: Registro creado.", null);
                }
                else
                {
                    return new GeneralAnswer(false, "Error al crear registro.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Registro, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/GetRegisters/{storeId}/{dateInit}/{dateEnd}")]
        public async Task<GeneralAnswer> GetRegisters(string storeId, string dateInit, string dateEnd)
        {
            try
            {
                int id = int.Parse(storeId);
                DateTime dateInitDT = DateTime.Parse(dateInit);
                DateTime dateEndDT = DateTime.Parse(dateEnd);
                
                return new GeneralAnswer(true, "Exitoso: Registros obtenidos.", RegisterDTO.FromDBToDTO(await _registerOP.GetRegisters(id, dateInitDT, dateEndDT)));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Registros, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
