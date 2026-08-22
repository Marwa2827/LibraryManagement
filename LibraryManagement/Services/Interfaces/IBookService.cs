using LibraryManagement.DTOs.Books;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookResponseDto>> GetAllAsync();

        Task<BookResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string? Error, BookResponseDto? Book)>
            CreateAsync(CreateBookDto dto);

        Task<(bool Success, string? Error)>
            UpdateAsync(int id, UpdateBookDto dto);

        Task<(bool Success, string? Error)>
            DeleteAsync(int id);
    }
}
