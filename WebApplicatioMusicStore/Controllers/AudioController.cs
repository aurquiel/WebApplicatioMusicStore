using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using WebApplicatioMusicStore.Models;
using WebApplicatioMusicStore.FilesHandlers;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace WebApplicatioMusicStore.Controllers
{
    [ApiController]
    public class AudioController : ControllerBase
    {
        private IWebHostEnvironment _env;
        private FileHandler _fileHandler;

        private string FOLDER_AUDIO = $"assets\\audio";
        private string FILE_LIST_AUDIO_PATH = $"assets\\audioList.txt";

        public AudioController(IWebHostEnvironment env)
        {
            _env = env; 
            _fileHandler = new FileHandler(_env);
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudioList")]
        public async Task<GeneralAnswer> DownloadAudioList()
        {
            try
            {
                var filePath = Path.Combine(_env.WebRootPath, FILE_LIST_AUDIO_PATH);
                var plainText = await _fileHandler.GetAudioListPlainText(filePath);
                return new GeneralAnswer(true, "Archivo de lista de audio obtenido", plainText);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Excepcion: " + ex.Message, null);
            }
           
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioList")]
        public async Task<GeneralAnswer> SynchronizeAudioList([FromBody] string textfile)
        {
            try
            {
                var textAuidoList = textfile.Split(Environment.NewLine).ToList();
                var result = await _fileHandler.SynchronizeAudioListAsync(textAuidoList, FILE_LIST_AUDIO_PATH, FOLDER_AUDIO);
                
                return new GeneralAnswer(true, "Exitosa: Sincronizacion de Archivo y canciones.", null);
            }
            catch(Exception ex) 
            {
                return new GeneralAnswer(false, "Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/UploadAudio")]
        public async Task<GeneralAnswer> UploadAudio(IFormFile file)
        {
            try
            {
                var result = await _fileHandler.AudioSaverAsync(file, FOLDER_AUDIO, FILE_LIST_AUDIO_PATH);
                if(result.Item1 == false)
                {
                    return new GeneralAnswer(result.Item1, result.Item2, null);
                }
                return new GeneralAnswer(result.Item1, result.Item2, null);
            }
            catch(Exception ex) 
            { 
                return new GeneralAnswer(false, "Excepcion: " + ex.Message, null);
            }
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudio")]
        public async Task<IActionResult> DownloadAudio(string audioName)
        {
                var filePath = Path.Combine(_env.WebRootPath, FOLDER_AUDIO, audioName);
                var provider = new FileExtensionContentTypeProvider();
                if(!provider.TryGetContentType(filePath, out var contentType))             
                {
                    contentType = "application/octet-stream";
                }

                var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(bytes, contentType, Path.GetFileName(filePath));
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("api/[controller]/DeleteAudio/{audioName}")]
        public async Task<GeneralAnswer> DeleteAudio(string audioName)
        {
            try
            {
                var result = await _fileHandler.AudioDeleteAsync(audioName, FOLDER_AUDIO, FILE_LIST_AUDIO_PATH);
                if (result.Item1 == false)
                {
                    return new GeneralAnswer(result.Item1, result.Item2, null);
                }
                return new GeneralAnswer(result.Item1, result.Item2, null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Excepcion: " + ex.Message, null);
            }
        }
    }
}
