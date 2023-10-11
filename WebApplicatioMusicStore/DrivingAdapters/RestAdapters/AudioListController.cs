using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    public class AudioListController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAudioListDriving _audioListDriving;

        public AudioListController(IMapper mapper, IAudioListDriving audioListDriving)
        {
            _mapper = mapper;
            _audioListDriving = audioListDriving;
        }

        [HttpGet, Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/DownloadAudioListStore/{storeId}")]
        public async Task<GeneralAnswerDto<List<AudioFileDto>>> DownloadAudioListStore(int storeId)
        {
            try
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(true, $"Succesful audio list obtained from store: {storeId}",  _mapper.Map<List<AudioFile>, List<AudioFileDto>>(await _audioListDriving.GetAudioListStoreAsync(storeId)));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(false, $"Error webservice obtaining audio list store {storeId}, Exception: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListStore")]
        public async Task<GeneralAnswerDto<object>> SynchronizeAudioListStore(SynchronizeAudioListStoreDto synchronizeAudioListStoreInfo)
        {
            try
            {
                await _audioListDriving.SynchronizeAudioListStoreAsync(_mapper.Map<List<AudioFileDto>, List<AudioFile>>(synchronizeAudioListStoreInfo.audioList), synchronizeAudioListStoreInfo.storeId);
                return new GeneralAnswerDto<object>(true, $"Audio List Store: {synchronizeAudioListStoreInfo.storeId}, synchronized.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice synchronizing audio list store: {synchronizeAudioListStoreInfo.storeId}, Exception: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListAllStore")]
        public async Task<GeneralAnswerDto<object>> SynchronizeAudioListAllStore()
        {
            try
            {
                await _audioListDriving.SynchronizeAudioListAllStoreAsync();
                return new GeneralAnswerDto<object>(true, "All audio list from stores have been successfully synchronized", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, "Error webservice synchronizing all audio list from stores, Exception: " + ex.Message, null);
            }
        }
    }
}
