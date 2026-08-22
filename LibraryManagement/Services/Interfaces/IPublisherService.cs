using LibraryManagement.DTOs.Publishers;

namespace LibraryManagement.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherResponseDto>> GetAllAsync();

        Task<PublisherResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string? Error, PublisherResponseDto? Publisher)>
            CreateAsync(PublisherDto dto);

        Task<(bool Success, string? Error)>
            UpdateAsync(int id, PublisherDto dto);

        Task<(bool Success, string? Error)>
            DeleteAsync(int id);
    }
}
