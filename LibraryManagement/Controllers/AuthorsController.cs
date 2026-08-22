using LibraryManagement.DTOs.Authors;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound(new
                {
                    message = "Author not found."
                });
            }

            return Ok(author);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Create(AuthorDto dto)
        {
            var result = await _authorService.CreateAsync(dto);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Author!.Id },
                result.Author);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Update(
            int id,
            AuthorDto dto)
        {
            var result = await _authorService.UpdateAsync(id, dto);

            if (!result.Success)
            {
                if (result.Error == "Author not found.")
                    return NotFound(new { message = result.Error });

                return BadRequest(new { message = result.Error });
            }

            return Ok(new
            {
                message = "Author updated successfully."
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _authorService.DeleteAsync(id);

            if (!result.Success)
            {
                if (result.Error == "Author not found.")
                    return NotFound(new { message = result.Error });

                return BadRequest(new { message = result.Error });
            }

            return Ok(new
            {
                message = "Author deleted successfully."
            });
        }
    }
}
