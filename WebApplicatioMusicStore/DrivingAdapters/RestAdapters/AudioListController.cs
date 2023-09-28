using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
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
        [Route("api/[controller]/DownloadAudioListStore/{storeCode}")]
        public async Task<GeneralAnswerDto<List<AudioFileDto>>> DownloadAudioListStore(string storeCode)
        {
            try
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(true, $"Succesful audio list obtained from store: {storeCode}",  _mapper.Map<List<AudioFile>, List<AudioFileDto>>(await _audioListDriving.GetAudioListStoreAsync(storeCode)));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(false, $"Error webservice obtaining audio list store {storeCode}, Exception: " + ex.Message, null);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListStore")]
        public async Task<GeneralAnswerDto<object>> SynchronizeAudioListStore(SynchronizeAudioListStoreDto synchronizeAudioListStoreInfo)
        {
            try
            {
                await _audioListDriving.SynchronizeAudioListStoreAsync(_mapper.Map<List<AudioFileDto>, List<AudioFile>>(synchronizeAudioListStoreInfo.audioList), synchronizeAudioListStoreInfo.storeCode);
                return new GeneralAnswerDto<object>(true, $"Audio List Store: {synchronizeAudioListStoreInfo.storeCode}, synchronized.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice synchronizing audio list store: {synchronizeAudioListStoreInfo.storeCode}, Exception: " + ex.Message, null);
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
