using Microsoft.AspNetCore.Mvc;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.FilesHandlers;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicatioMusicStore.Controllers
{
    [ApiController]
    public class AudioController : ControllerBase
    {
        private IWebHostEnvironment _env;
        private FileHandler _fileHandler;

        public AudioController(IWebHostEnvironment env)
        {
            _env = env; 
            _fileHandler = new FileHandler(_env);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        [Route("api/[controller]/DownloadAudiosList")]
        public async Task<GeneralAnswer<string>> DownloadAudiosList()
        {
            try
            {
                return new GeneralAnswer<string>(true, $"Archivo de lista de audios obtenido", await _fileHandler.GetAudioListAsync());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<string>(false, "Error webservice DownloadAudiosList, Excepcion: " + ex.Message, null);
            }
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudioListStore/{storeCode}")]
        public async Task<GeneralAnswer<string>> DownloadAudioListStore(string storeCode)
        {
            try
            {
                return new GeneralAnswer<string>(true, $"Archivo de lista de audio obtenido tienda:{storeCode}", await _fileHandler.GetAudioListStoreAsync(storeCode));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<string>(false, "Error webservice DownloadAudioListStore, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioList")]
        public async Task<GeneralAnswer<object>> SynchronizeAudioList(string audioList, string storeCode)
        {
            try
            {
                await _fileHandler.SynchronizeAudioListStoreAsync(audioList, storeCode);
                return new GeneralAnswer<object>(true, "Exitosa: Sincronizacion de Archivo y canciones.", null);
            }
            catch(Exception ex) 
            {
                return new GeneralAnswer<object>(false, "Error webservice SynchronizeAudioList, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/UploadAudio")]
        public async Task<GeneralAnswer<object>> UploadAudio(IFormFile file)
        {
            try
            {
                var result = await _fileHandler.AudioSaveAsync(file);
                if(result.Item1 == false)
                {
                    return new GeneralAnswer<object>(result.Item1, result.Item2, null);
                }
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
            catch(Exception ex) 
            { 
                return new GeneralAnswer<object>(false, "Error webservice UploadAudio, Excepcion: " + ex.Message, null);
            }
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudio")]
        public async Task<IActionResult> DownloadAudio(string audioName)
        {
            return File(await _fileHandler.AudioDownloadGetBytesAsync(audioName), "application/octet-stream", audioName);
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("api/[controller]/DeleteAudios")]
        public async Task<GeneralAnswer<object>> DeleteAudios(List<string> audioNamesList)
        {
            try
            {
                await _fileHandler.AudioDeleteAsync(audioNamesList);
                return new GeneralAnswer<object>(true, "Archivos de audio eliminados.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Excepcion: " + ex.Message, null);
            }
        }
    }
}
