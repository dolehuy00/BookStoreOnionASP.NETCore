using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Service;
using Service.Abstractions;
using Shared;
using Shared.Api;

namespace Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private IAuthService _authService;
        private readonly TokenService _tokenServ;

        public AuthApiController(IAuthService authService, TokenService tokenService)
        {
            _authService = authService;
            _tokenServ = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> CheckLogin([FromBody] LoginDTO loginDTO)
        {
            try
            {
                // verify account
                var user = await _authService.VerifyUser(loginDTO.Email, loginDTO.Password);
                if (user != null)
                {
                    var accessToken = _tokenServ.GenerateAccessToken(user.Id.ToString(), "user.RoleName!");
                    var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    var response = new
                    {
                        user.Id,
                        accessToken,
                        user.Email
                    };
                    return Ok(new ResponseObjectDTO<dynamic>("Login successfully", response));
                }
                var passwordMessage = new { Password = "Password or account is incorrect." };
                return Unauthorized(
                    new ResponseMessageDTO("Can't login.", 401, [passwordMessage]));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
