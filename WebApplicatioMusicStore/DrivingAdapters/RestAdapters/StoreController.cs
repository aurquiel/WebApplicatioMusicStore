using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStoreDriving _storeDriving;

        public StoreController(IMapper mapper, IStoreDriving storeDriving)
        {
            _mapper = mapper;
            _storeDriving = storeDriving;
        }

        [HttpGet(), Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/StoreGetAll")]
        public async Task<GeneralAnswerDto<List<StoreDto>>> StoreGetAll()
        {
            try
            {
                return new GeneralAnswerDto<List<StoreDto>>(true, "List of Stores obatianed successfully", _mapper.Map<List<Store>, List<StoreDto>>(await _storeDriving.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<StoreDto>>(false, "Error webservice obtaining List of Stores, Exception: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreInsert")]
        public async Task<GeneralAnswerDto<object>> StoreInsert(StoreDto storeDTO)
        {
            try
            {
                await _storeDriving.InsertAsync(_mapper.Map<Store>(storeDTO));
                return new GeneralAnswerDto<object>(true, $"Store: {storeDTO.Code}, created Successfully", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice creating store: {storeDTO.Code}, Exception: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreUpdate")]
        public async Task<GeneralAnswerDto<object>> StoreUpdate(StoreDto storeDTO)
        {
            try
            {
                await _storeDriving.UpdateAsync(_mapper.Map<Store>(storeDTO));
                return new GeneralAnswerDto<object>(true, $"Store: {storeDTO.Code}, updated Successfully", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice updating store: {storeDTO.Code}, Exception: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreDelete/{storeId}")]
        public async Task<GeneralAnswerDto<object>> StoreDelete(int storeId)
        {
            try
            {
                await _storeDriving.DeleteAsync(storeId);
                return new GeneralAnswerDto<object>(true, $"Store id: {storeId}, deleted Successfully", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice deleting store id: {storeId}, Exception: " + ex.Message, null);
            }
        }
    }
}
