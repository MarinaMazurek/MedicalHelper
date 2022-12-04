using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.WebAPI.Models.Requests;
using MedicalHelper.WebAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicalHelper.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IJwtUtilSha256 _jwtUtil;

        public UserController(IUserService userService, 
            IRoleService roleService, IMapper mapper, IJwtUtilSha256 jwtUtil)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
            _jwtUtil = jwtUtil;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            return Ok(userDto);
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsersDto = await _userService.GetAllUsersAsync();
            return Ok(allUsersDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserRequestModel model)
        {
            try
            {
                var userRoleId = await _roleService.GetRoleIdByNameAsync("User");

                var userDto = _mapper.Map<UserDto>(model);
                userDto.RoleId = userRoleId.Value;

                var userDtoReturn = await _userService
                    .GetUserByEmailAndPasswordAsync(model.Email, model.Password);

                if (userDto != null && userRoleId != null && userDtoReturn == null)
                {
                    
                    userDto.Id = Guid.NewGuid();                                       

                    await _userService.AddAsync(userDto);

                    var userInDbDto = await _userService.GetUserByEmailAsync(userDto.Email);

                    var response = await _jwtUtil.GenerateTokenAsync(userInDbDto);

                    return Ok(response);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest(500);
            }
        }
    }
}
