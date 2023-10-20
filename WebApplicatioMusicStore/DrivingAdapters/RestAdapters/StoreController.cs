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
                return new GeneralAnswerDto<List<StoreDto>>(true, "Lista de Tiendas obtenida exitosamente.", _mapper.Map<List<Store>, List<StoreDto>>(await _storeDriving.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<StoreDto>>(false, "Error webservice obteniendo Lista de Teindas, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreInsert")]
        public async Task<GeneralAnswerDto<object>> StoreInsert(StoreDto storeDTO)
        {
            try
            {
                await _storeDriving.InsertAsync(_mapper.Map<Store>(storeDTO));
                return new GeneralAnswerDto<object>(true, $"Tienda: {storeDTO.Code}, creada exitosamente.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice creando tienda: {storeDTO.Code}, Excepcion: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreUpdate")]
        public async Task<GeneralAnswerDto<object>> StoreUpdate(StoreDto storeDTO)
        {
            try
            {
                await _storeDriving.UpdateAsync(_mapper.Map<Store>(storeDTO));
                return new GeneralAnswerDto<object>(true, $"Tienda: {storeDTO.Code}, actualizada exitosamente.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice actulizando tienda: {storeDTO.Code}, Excepcion: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/StoreDelete/{storeId}")]
        public async Task<GeneralAnswerDto<object>> StoreDelete(int storeId)
        {
            try
            {
                await _storeDriving.DeleteAsync(storeId);
                return new GeneralAnswerDto<object>(true, $"Tienda id: {storeId}, eliminada exitosamente.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice eliminando tienda id: {storeId}, Excepcion: " + ex.Message, null);
            }
        }
    }
}
