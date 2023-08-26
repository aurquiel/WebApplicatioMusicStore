using Microsoft.AspNetCore.Mvc;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.FilesHandlers;
using Microsoft.AspNetCore.Authorization;
using WebApplicationMusicStore.Models;
using System.Collections.Generic;

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
        [Route("api/[controller]/DownloadAudioListServer")]
        public async Task<GeneralAnswer<List<AudioFile>>> DownloadAudiosListServer()
        {
            try
            {
                return new GeneralAnswer<List<AudioFile>>(true, $"Archivo de lista de audios obtenido", await _fileHandler.GetAudioListAsync());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<AudioFile>>(false, "Error webservice DownloadAudiosList, Excepcion: " + ex.Message, null);
            }
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudioListStore/{storeCode}")]
        public async Task<GeneralAnswer<List<AudioFile>>> DownloadAudioListStore(string storeCode)
        {
            try
            {
                return new GeneralAnswer<List<AudioFile>> (true, $"Archivo de lista de audio obtenido tienda:{storeCode}", await _fileHandler.GetAudioListStoreAsync(storeCode));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<AudioFile>>(false, "Error webservice DownloadAudioListStore, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListStore")]
        public async Task<GeneralAnswer<object>> SynchronizeAudioListStore(SynchronizeAudioListStoreInfo synchronizeAudioListStoreInfo)
        {
            try
            {
                await _fileHandler.SynchronizeAudioListStoreAsync(synchronizeAudioListStoreInfo.audioList, synchronizeAudioListStoreInfo.storeCode);
                return new GeneralAnswer<object>(true, $"Lista de audio tienda: {synchronizeAudioListStoreInfo.storeCode} sincronizada.",null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error webservice SynchronizeAudioListStore, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListAllStore")]
        public async Task<GeneralAnswer<object>> SynchronizeAudioListAllStore()
        {
            try
            {
                await _fileHandler.SynchronizeAudioListAllStoreAsync();
                return new GeneralAnswer<object>(true, "Sincronizacion de lista de audio de las tiendas.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error webservice SynchronizeAudioListAllStore, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/UploadAudio")]
        public async Task<GeneralAnswer<object>> UploadAudio(IFormFile file)
        {
            try
            {
                var result = await _fileHandler.AudioSaveAsync(file);
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error webservice UploadAudio, Excepcion: " + ex.Message, null);
            }
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudio/{audioName}")]
        public async Task<IActionResult> DownloadAudio(string audioName)
        {
            return File(await _fileHandler.AudioDownloadGetBytesAsync(audioName), "application/octet-stream", audioName);
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("api/[controller]/DeleteAudio")]
        public async Task<GeneralAnswer<object>> DeleteAudio([FromBody] string audioName)
        {
            try
            {
                await _fileHandler.AudioDeleteAsync(audioName);
                return new GeneralAnswer<object>(true, "Archivos de audio eliminados.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Excepcion: " + ex.Message, null);
            }
        }
    }
}
