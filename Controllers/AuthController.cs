using Microsoft.AspNetCore.Mvc;
using ZipZop.Modals;
using ZipZop.Common;
using ZipZop.Services.Interfaces;
using ZipZop.dtos;

namespace ZipZop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var user = await _authService.Register(dto);

            if (user == null)
            {
                return Conflict(new ApiResponse<string>(null!, ResponseMessages.UserAlreadyExists)
                {
                    Status = false
                });
            }

            var result = new RecordResultDto
            {
                Id = user.Id
            };

            return StatusCode(ResponseMessages.UserRegisteredCode,
                new ApiResponse<RecordResultDto>(result, ResponseMessages.UserRegistered));
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.Login(dto.Email, dto.Password);

            if (token == null)
                return Unauthorized(new ApiErrorResponse(ResponseMessages.InvalidCredentials, ResponseMessages.InvalidCredentialsCode));

            return Ok(new ApiResponse<object>(new { token }, "Login successful"));
        }
    }
}
