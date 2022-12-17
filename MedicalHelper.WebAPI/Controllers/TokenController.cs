using MedicalHelper.Core.Abstractions;
using MedicalHelper.WebAPI.Models.Requests;
using MedicalHelper.WebAPI.Models.Responses;
using MedicalHelper.WebAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicalHelper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtUtilSha256 _jwtUtil;

        public TokenController(IUserService userService, IJwtUtilSha256 jwtUtil)
        {
            _userService = userService;
            _jwtUtil = jwtUtil;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJwtToken([FromBody] LoginUserRequestModel request)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(request.Email);
                if (user == null)
                {
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Password is incorrect"
                    });
                }

                var response = await _jwtUtil.GenerateTokenAsync(user);

                return Ok(response);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500);
            }
        }
    }
}
