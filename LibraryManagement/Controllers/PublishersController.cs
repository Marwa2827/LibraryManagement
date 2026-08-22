using LibraryManagement.DTOs.Publishers;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publisherService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherService.GetByIdAsync(id);

            if (publisher == null)
                return NotFound(new { message = "Publisher not found." });

            return Ok(publisher);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Create(PublisherDto dto)
        {
            var result = await _publisherService.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(new { message = result.Error });

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Publisher!.Id },
                result.Publisher);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Update(
            int id,
            PublisherDto dto)
        {
            var result =
                await _publisherService.UpdateAsync(id, dto);

            if (!result.Success)
            {
                if (result.Error == "Publisher not found.")
                    return NotFound(new { message = result.Error });

                return BadRequest(new { message = result.Error });
            }

            return Ok(new
            {
                message = "Publisher updated successfully."
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _publisherService.DeleteAsync(id);

            if (!result.Success)
            {
                if (result.Error == "Publisher not found.")
                    return NotFound(new { message = result.Error });

                return BadRequest(new { message = result.Error });
            }

            return Ok(new
            {
                message = "Publisher deleted successfully."
            });
        }
    }
}
