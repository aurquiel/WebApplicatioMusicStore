using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
                return new GeneralAnswerDto<List<AudioFileDto>>(true, $"Lista de Audio de la tienda obtenida exitosamente.",  _mapper.Map<List<AudioFile>, List<AudioFileDto>>(await _audioListDriving.GetAudioListStoreAsync(storeId)));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<AudioFileDto>>(false, $"Error webservice obteniendo Lista de Audio de la tienda, tienda id: {storeId}, Excepcion: " + ex.Message, new List<AudioFileDto>());
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListStore")]
        public async Task<GeneralAnswerDto<object>> SynchronizeAudioListStore(SynchronizeAudioListStoreDto synchronizeAudioListStoreInfo)
        {
            try
            {
                await _audioListDriving.SynchronizeAudioListStoreAsync(_mapper.Map<List<AudioFileDto>, List<AudioFile>>(synchronizeAudioListStoreInfo.audioList), synchronizeAudioListStoreInfo.storeId);
                return new GeneralAnswerDto<object>(true, $"Lista de Audio de la tienda sincronizada.", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice sincronizando Lista de Audio de la tienda id: {synchronizeAudioListStoreInfo.storeId}, Excepcion: " + ex.Message, new object());
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("api/[controller]/SynchronizeAudioListAllStore")]
        public async Task<GeneralAnswerDto<object>> SynchronizeAudioListAllStore()
        {
            try
            {
                await _audioListDriving.SynchronizeAudioListAllStoreAsync();
                return new GeneralAnswerDto<object>(true, "Todas las Lista de Audio de las teindas syncronizadas.", new object());
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, "Error webservice sincronizando todas las Lista de Audio de las tiendas, Excepcion: " + ex.Message, new object());
            }
        }
    }
}
