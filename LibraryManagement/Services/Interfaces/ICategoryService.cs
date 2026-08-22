using LibraryManagement.DTOs.Categories;

namespace LibraryManagement.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();

        Task<CategoryResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string? Error, CategoryResponseDto? Category)>
            CreateAsync(CategoryDto dto);

        Task<(bool Success, string? Error)>
            UpdateAsync(int id, CategoryDto dto);

        Task<(bool Success, string? Error)>
            DeleteAsync(int id);
    }
}
