using LibraryManagement.DTOs.Users;
using LibraryManagement.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _userManager.Users.ToList();

            var result = new List<UserResponseDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserResponseDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email ?? string.Empty,
                    IsActive = user.IsActive,
                    Roles = roles
                });
            }

            return Ok(result);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound(new
                {
                    message = "User not found."
                });
            }

            var roles = await _userManager.GetRolesAsync(user);

            var result = new UserResponseDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                IsActive = user.IsActive,
                Roles = roles
            };

            return Ok(result);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            var validRoles = new[]
            {
                "Administrator",
                "Librarian",
                "Staff"
            };

            if (!validRoles.Contains(request.Role))
            {
                return BadRequest(new
                {
                    message = "Invalid role."
                });
            }

            if (!await _roleManager.RoleExistsAsync(request.Role))
            {
                return BadRequest(new
                {
                    message = "Role does not exist."
                });
            }

            var existingUser =
                await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return Conflict(new
                {
                    message = "A user with this email already exists."
                });
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                IsActive = true,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(
                user,
                request.Password);

            if (!createResult.Succeeded)
            {
                return BadRequest(new
                {
                    errors = createResult.Errors
                        .Select(e => e.Description)
                });
            }

            var roleResult = await _userManager.AddToRoleAsync(
                user,
                request.Role);

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                return BadRequest(new
                {
                    errors = roleResult.Errors
                        .Select(e => e.Description)
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.Id },
                new
                {
                    message = "User created successfully.",
                    userId = user.Id
                });
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateUserDto request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound(new
                {
                    message = "User not found."
                });
            }

            if (!await _roleManager.RoleExistsAsync(request.Role))
            {
                return BadRequest(new
                {
                    message = "Invalid role."
                });
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            user.FullName = request.FullName;
            user.IsActive = request.IsActive;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return BadRequest(new
                {
                    errors = updateResult.Errors
                        .Select(e => e.Description)
                });
            }

            await _userManager.RemoveFromRolesAsync(
                user,
                currentRoles);

            await _userManager.AddToRoleAsync(
                user,
                request.Role);

            return Ok(new
            {
                message = "User updated successfully."
            });
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound(new
                {
                    message = "User not found."
                });
            }

            user.IsActive = false;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    errors = result.Errors
                        .Select(e => e.Description)
                });
            }

            return Ok(new
            {
                message = "User deactivated successfully."
            });
        }
    }
}
