using LibraryManagement.DTOs.Borrowings;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BorrowingsController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;

        public BorrowingsController(
            IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        // GET: api/Borrowings
        [HttpGet]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> GetAll()
        {
            var borrowings =
                await _borrowingService.GetAllAsync();

            return Ok(borrowings);
        }

        // GET: api/Borrowings/5
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> GetById(int id)
        {
            var borrowing =
                await _borrowingService.GetByIdAsync(id);

            if (borrowing == null)
            {
                return NotFound(new
                {
                    message = "Borrowing record not found."
                });
            }

            return Ok(borrowing);
        }

        // POST: api/Borrowings
        [HttpPost]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> Borrow(
            CreateBorrowingDto dto)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid user token."
                });
            }

            var result =
                await _borrowingService.BorrowAsync(
                    dto,
                    userId.Value);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Borrowing!.Id },
                result.Borrowing);
        }

        // POST: api/Borrowings/5/return
        [HttpPost("{id:int}/return")]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> Return(int id)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid user token."
                });
            }

            var result =
                await _borrowingService.ReturnAsync(
                    id,
                    userId.Value);

            if (!result.Success)
            {
                if (result.Error == "Borrowing record not found.")
                {
                    return NotFound(new
                    {
                        message = result.Error
                    });
                }

                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return Ok(new
            {
                message = "Book returned successfully."
            });
        }

        private int? GetCurrentUserId()
        {
            var userIdClaim =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userIdClaim, out var userId))
            {
                return userId;
            }

            return null;
        }
    }
}
