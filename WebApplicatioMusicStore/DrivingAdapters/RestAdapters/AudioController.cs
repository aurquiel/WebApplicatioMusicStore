using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using AutoMapper;
using ClassLibraryDomain.Ports.Driving;
using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Route("api/[controller]")]
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
                return new GeneralAnswerDto<List<AudioFileDto>>(true, $"Audio List Server obtained successfully", _mapper.Map<List<AudioFile>,  List<AudioFileDto>>(await _audioDriving.GetAudioListAsync()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(false, "Error webservice obtaining Audio List from server, Exception: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/UploadAudio")]
        public async Task<GeneralAnswerDto<object>> UploadAudio(IFormFile file)
        {
            try
            {
                await _audioDriving.AudioSaveAsync(file.Name ,file.OpenReadStream());
                return new GeneralAnswerDto<object>(true, $"Audio: {file.Name}, successfully upload to server.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, "Error webservice uploading audio, Exception: " + ex.Message, null);
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
                return new GeneralAnswerDto<object>(true, $"Audio: {audioName} successfully deleted", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error wenservice deleting audio {audioName}, Exception: " + ex.Message, null);
            }
        }
    }
}
