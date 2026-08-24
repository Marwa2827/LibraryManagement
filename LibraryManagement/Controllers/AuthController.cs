using LibraryManagement.DTOs.Auth;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IUserActivityLogService _activityLogService;

        public AuthController(UserManager<ApplicationUser> userManager
            ,IJwtService jwtService,IUserActivityLogService activityLogService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _activityLogService = activityLogService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }

            if (!user.IsActive)
            {
                return Unauthorized(new
                {
                    message = "Your account is inactive."
                });
            }

            var passwordValid = await _userManager.CheckPasswordAsync(
                user,
                request.Password);

            if (!passwordValid)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }

            var result = await _jwtService.GenerateTokenAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            await _activityLogService.LogAsync(
                user.Id,
                "Login",
                "ApplicationUser",
                user.Id,
                HttpContext.Connection.RemoteIpAddress?.ToString());

            var response = new LoginResponseDto
            {
                Token = result.Token,
                ExpiresAt = result.ExpiresAt,
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                Roles = roles
            };

            return Ok(response);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userIdClaim =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized(new
                {
                    message = "Invalid user token."
                });
            }

            await _activityLogService.LogAsync(
                userId,
                "Logout",
                "ApplicationUser",
                userId,
                HttpContext.Connection.RemoteIpAddress?.ToString());

            return Ok(new
            {
                message = "Logout successful."
            });
        }
    }
}
