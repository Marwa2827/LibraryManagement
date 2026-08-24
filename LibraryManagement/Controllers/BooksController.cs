using LibraryManagement.DTOs.Books;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound(new
                {
                    message = "Book not found."
                });
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Create(
            [FromForm] CreateBookDto dto)
        {
            var result = await _bookService.CreateAsync(dto);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Book!.Id },
                result.Book);
        }

        // PUT: api/books/5
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Update(
            int id,
            [FromForm] UpdateBookDto dto)
        {
            var result = await _bookService.UpdateAsync(id, dto);

            if (!result.Success)
            {
                if (result.Error == "Book not found.")
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
                message = "Book updated successfully."
            });
        }

        // DELETE: api/books/5
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);

            if (!result.Success)
            {
                if (result.Error == "Book not found.")
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
                message = "Book deleted successfully."
            });
        }
    }
}
