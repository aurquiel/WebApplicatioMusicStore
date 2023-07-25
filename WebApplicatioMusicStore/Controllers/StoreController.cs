using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.DTO;
using WebApplicatioMusicStore.Operations;
using WebApplicatioMusicStore.FilesHandlers;

namespace WebApplicatioMusicStore.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IStoreOP _storeOP;
        private FileHandler _filesHandler;

        public StoreController(IStoreOP storeOP, IWebHostEnvironment env)
        {
            _storeOP = storeOP;
            _filesHandler = new FileHandler(env);
        }

        [HttpGet(), Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/StoreGetAll")]
        public async Task<GeneralAnswer<List<StoreDTO>>> StoreGetAll()
        {
            try
            {
                return new GeneralAnswer<List<StoreDTO>>(true, "Exitoso: Tiendas obtenidas.", StoreDTO.FromDBToDTO(await _storeOP.GetAll()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<StoreDTO>>(false, "Error obteniendo Tiendas, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreInsert")]
        public async Task<GeneralAnswer<object>> StoreInsert(StoreDTO storeDTO)
        {
            try
            {
                var result = await _storeOP.Insert(StoreDTO.FromDTOToDB(storeDTO));
                if (result.Status)
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Tienda creada.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(result.Status, result.StatusMessage, null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error creando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreUpdate")]
        public async Task<GeneralAnswer<object>> StoreUpdate(StoreDTO storeDTO)
        {
            try
            {
                var result = await _storeOP.Update(StoreDTO.FromDTOToDB(storeDTO));
                if (result.Status)
                {
                    _filesHandler.RenameAudioListStoreFile("audioList" + result.Data + ".txt", "audioList" + storeDTO.Code + ".txt");
                    return new GeneralAnswer<object>(true, "Exitoso: Tienda editada.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(result.Status, result.StatusMessage, null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error editando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreDelete")]
        public async Task<GeneralAnswer<object>> StoreDelete(StoreDTO storeDTO)
        {
            try
            {
                if (await _storeOP.Delete(StoreDTO.FromDTOToDB(storeDTO)))
                {
                    return new GeneralAnswer<object>(true, "Exitoso: Tienda eliminada.", null);
                }
                else
                {
                    return new GeneralAnswer<object>(false, "Error al eliminar tienda.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error eliminando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
