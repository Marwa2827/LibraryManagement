using LibraryManagement.DTOs.Borrowings;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBorrowingService
    {
        Task<List<BorrowingResponseDto>> GetAllAsync();

        Task<BorrowingResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string? Error, BorrowingResponseDto? Borrowing)>
            BorrowAsync(
                CreateBorrowingDto dto,
                int userId);

        Task<(bool Success, string? Error)>
            ReturnAsync(
                int borrowingId,
                int userId);
    }
}
