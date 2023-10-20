using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using AutoMapper;
using ClassLibraryDomain.Ports.Driving;
using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAudioDriving _audioDriving;

        public AudioController(IMapper mapper, IAudioDriving audioDriving)
        {
            _mapper = mapper;
            _audioDriving = audioDriving;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        [Route("api/[controller]/DownloadAudioListServer")]
        public async Task<GeneralAnswerDto<List<AudioFileDto>>> DownloadAudiosListServer()
        {
            try
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(true, $"Lista de Audio del servidor obtenido exitosamente.", _mapper.Map<List<AudioFile>,  List<AudioFileDto>>(await _audioDriving.GetAudioListAsync()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(false, "Error webservice obteniendo Lista de Audio del servisor, Excepcion: " + ex.Message, new List<AudioFileDto>());
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/UploadAudio")]
        public async Task<GeneralAnswerDto<object>> UploadAudio(IFormFile file)
        {
            try
            {
                await _audioDriving.AudioSaveAsync(file.FileName ,file.OpenReadStream());
                return new GeneralAnswerDto<object>(true, $"Audio: {file.FileName}, subido exitosamente al servidor.", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice subiendo audio: {file.FileName}, Excepcion: " + ex.Message, new object());
            }
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudio/{audioName}")]
        public async Task<IActionResult> DownloadAudio(string audioName)
        {
            return File(await _audioDriving.AudiodGetBytesAsync(audioName), "application/octet-stream", audioName);
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("api/[controller]/DeleteAudio")]
        public async Task<GeneralAnswerDto<object>> DeleteAudio([FromBody] string audioName)
        {
            try
            {
                await _audioDriving.AudioDeleteAsync(audioName);
                return new GeneralAnswerDto<object>(true, $"Audio: {audioName} eliminado exitosamente", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice eliminando audio: {audioName}, Exception: " + ex.Message, new object());
            }
        }
    }
}
