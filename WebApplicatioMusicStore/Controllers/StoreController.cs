using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.DTO;
using WebApplicatioMusicStore.Operations;

namespace WebApplicatioMusicStore.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IStoreOP _storeOP;

        public StoreController(IStoreOP storeOP)
        {
            _storeOP = storeOP;
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreGetAll")]
        public async Task<GeneralAnswer> StoreGetAll()
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Tiendas obtenidas.", StoreDTO.FromDBToDTO(await _storeOP.GetAll()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Tiendas, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreInsert")]
        public async Task<GeneralAnswer> StoreInsert(StoreDTO storeDTO)
        {
            try
            {
                if (await _storeOP.Insert(StoreDTO.FromDTOToDB(storeDTO)))
                {
                    return new GeneralAnswer(true, "Exitoso: Tienda creada.", null);
                }
                else
                {
                    return new GeneralAnswer(false, "Error al crear tienda.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreUpdate")]
        public async Task<GeneralAnswer> StoreUpdate(StoreDTO storeDTO)
        {
            try
            {
                if (await _storeOP.Update(StoreDTO.FromDTOToDB(storeDTO)))
                {
                    return new GeneralAnswer(true, "Exitoso: Tienda editada.", null); 
                }
                else
                {
                    return new GeneralAnswer(false, "Error al editar tienda.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreDelete")]
        public async Task<GeneralAnswer> StoreDelete(StoreDTO storeDTO)
        {
            try
            {
                if (await _storeOP.Delete(StoreDTO.FromDTOToDB(storeDTO)))
                {
                    return new GeneralAnswer(true, "Exitoso: Tienda eliminada.", null);
                }
                else
                {
                    return new GeneralAnswer(false, "Error al eliminar tienda.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
