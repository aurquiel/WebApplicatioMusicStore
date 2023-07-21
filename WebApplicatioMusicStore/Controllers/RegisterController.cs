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

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/GetRegisters/{storeId}/{dateInit}/{dateEnd}")]
        public async Task<GeneralAnswer<List<RegisterDTO>>> GetRegisters(int storeId, string dateInit, string dateEnd)
        {
            try
            {
                DateTime dateInitDT = DateTime.Parse(dateInit);
                DateTime dateEndDT = DateTime.Parse(dateEnd);

                return new GeneralAnswer<List<RegisterDTO>>(true, "Exitoso: Registros obtenidos.", RegisterDTO.FromDBToDTO(await _registerOP.GetRegisters(storeId, dateInitDT, dateEndDT)));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<RegisterDTO>>(false, "Error obteniendo Registros, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/GetRegistersByDate/{date}/")]
        public async Task<GeneralAnswer<List<RegisterDTO>>> GetRegistersByDate(string date)
        {
            try
            {
                DateTime dateParse = DateTime.Parse(date);
                return new GeneralAnswer<List<RegisterDTO>>(true, "Exitoso: Registros obtenidos.", RegisterDTO.FromDBToDTO(await _registerOP.GetRegistersByDate(dateParse)));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<RegisterDTO>>(false, "Error obteniendo Registros, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/RegisterInsert")]
        public async Task<GeneralAnswer<object>> RegisterInsert(RegisterDTO registerDTO)
        {
            try
            {
                if (await _registerOP.Insert(RegisterDTO.FromDTOToDB(registerDTO)))
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Registro creado.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(false, "Error al crear registro.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error creando Registro, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/RegisterDelete/{storeId}")]
        public async Task<GeneralAnswer<object>> RegisterDelete(int storeId)
        {
            try
            {
                if (await _registerOP.DeleteAllStoreId(storeId))
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Registros.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(false, "Error al crear registro.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error creando Registro, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
