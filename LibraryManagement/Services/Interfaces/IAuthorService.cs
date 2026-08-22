using LibraryManagement.DTOs.Authors;

namespace LibraryManagement.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorResponseDto>> GetAllAsync();

        Task<AuthorResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string? Error, AuthorResponseDto? Author)>
            CreateAsync(AuthorDto dto);

        Task<(bool Success, string? Error)>
            UpdateAsync(int id, AuthorDto dto);

        Task<(bool Success, string? Error)>
            DeleteAsync(int id);
    }
}
