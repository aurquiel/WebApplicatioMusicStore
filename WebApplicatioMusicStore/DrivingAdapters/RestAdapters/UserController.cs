using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using WebApplicationMusicStore.DrivingAdapters.Utils;
using AutoMapper;
using ClassLibraryDomain.Ports.Driving;
using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserDriving _userDriving;

        public UserController(IMapper mapper, IUserDriving userDriving)
        {
            _mapper = mapper;
            _userDriving = userDriving;
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserGetAll")]
        public async Task<GeneralAnswerDto<List<UserDto>>> UserGetAll()
        {
            try
            {
                return new GeneralAnswerDto<List<UserDto>>(true, "List of Users obtained successfully", _mapper.Map<List<User>, List<UserDto>>(await _userDriving.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<List<UserDto>>(false, "Error webservice obtaining List of Users, Exception: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserInsert")]
        public async Task<GeneralAnswerDto<object>> UserInsert(UserDto userDTO)
        {
            try
            {
                userDTO.Password = Hash256.HashOfUserPassword(userDTO.Password);
                await _userDriving.InsertAsync(_mapper.Map<User>(userDTO));
                return new GeneralAnswerDto<object>(true, "User created successfully", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, "Error webservice creating user, Exception: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserUpdate")]
        public async Task<GeneralAnswerDto<object>> UserUpdate(UserDto userDTO)
        {
            try
            {
                userDTO.Password = Hash256.HashOfUserPassword(userDTO.Password);
                await _userDriving.UpdateAsync(_mapper.Map<User>(userDTO));
                return new GeneralAnswerDto<object>(true, "User edited successfully", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice editing user id: {userDTO.Id}, Exception: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize(Roles = "Admin")]
        [Route("api/[controller]/UserDelete/{userId}")]
        public async Task<GeneralAnswerDto<object>> UserDelete(int userId)
        {
            try
            {
                await _userDriving.DeleteAsync(userId);
                return new GeneralAnswerDto<object>(true, "User deleted successfully", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto<object>(false, $"Error webservice deleting user id: {userId}, Exception: " + ex.Message, null);
            }
        }
    }
}
