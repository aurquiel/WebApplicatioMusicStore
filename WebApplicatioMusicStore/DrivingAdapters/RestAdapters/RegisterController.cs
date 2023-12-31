﻿using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegisterDriving _registerDriving;

        public RegisterController(IMapper mapper, IRegisterDriving registerDriving)
        {
            _mapper = mapper;
            _registerDriving = registerDriving;
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/GetRegisters/{storeId}/{dateInit}/{dateEnd}")]
        public async Task<GeneralAnswerDto<List<RegisterDto>>> GetRegisters(int storeId, string dateInit, string dateEnd)
        {
            try
            {
                return new GeneralAnswerDto<List<RegisterDto>>(true, "Registers obtained successfully", _mapper.Map<List<Register>, List<RegisterDto>>(await _registerDriving.GetByIdAndRangeDateAsync(storeId, DateTime.Parse(dateInit), DateTime.Parse(dateEnd))));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<RegisterDto>>(false, "Error webservice obtaining Registers, Exception: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/GetRegistersByMonth/{storeId}/{date}/")]
        public async Task<GeneralAnswerDto<List<RegisterDto>>> GetRegistersByMonth(int storeId, string date)
        {
            try
            {
                return new GeneralAnswerDto<List<RegisterDto>>(true, "Registers obtained successfully", _mapper.Map<List<Register>, List<RegisterDto>>(await _registerDriving.GetByIdAndMonthAsync(storeId, DateTime.Parse(date))));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<RegisterDto>>(false, "Error webservice obtaining Registers by month, Exception: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize(Roles = "Admin, Store")]
        [Route("api/[controller]/RegisterInsert")]
        public async Task<GeneralAnswerDto<object>> RegisterInsert(List<RegisterDto> registersDto)
        {
            try
            {
                await _registerDriving.InsertAsync(_mapper.Map<List<RegisterDto>, List<Register>>(registersDto));
                return new GeneralAnswerDto<object>(true, "Registers successfullty created.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, "Error webservice creating registers, Exception: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/RegisterDelete/{storeId}")]
        public async Task<GeneralAnswerDto<object>> RegisterDelete(int storeId)
        {
            try
            {
                await _registerDriving.DeleteAllByStoreIdAsync(storeId);
                return new GeneralAnswerDto<object>(true, $"Registers sucessfully deleted, store id: {storeId}", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice deleting registers store id: {storeId}, Exception: " + ex.Message, null);
            }
        }
    }
}
