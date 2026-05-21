using EnquiryManagement.API.DTOs;
using EnquiryManagement.API.Helpers;
using EnquiryManagement.API.Interfaces;
using EnquiryManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnquiryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        private readonly JwtHelper _jwtHelper;

        public AuthController(
            IUserRepository userRepository,
            JwtHelper jwtHelper)
        {
            _userRepository = userRepository;

            _jwtHelper = jwtHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existingUser =
                await _userRepository.GetUserByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return BadRequest(new
                {
                    message = "Email already exists"
                });
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,

                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(dto.Password),

                Role = "User"
            };

            await _userRepository.RegisterUserAsync(user);

            return Ok(new
            {
                message = "User registered successfully"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user =
                await _userRepository.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password"
                });
            }

            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password"
                });
            }

            var token = _jwtHelper.GenerateToken(user);

            return Ok(new
            {
                token
            });
        }
    }
}
