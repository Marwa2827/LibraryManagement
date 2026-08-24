using LibraryManagement.DTOs.Members;

namespace LibraryManagement.Services.Interfaces
{
    public interface IMemberService
    {
        Task<List<MemberResponseDto>> GetAllAsync();

        Task<MemberResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string? Error, MemberResponseDto? Member)>
            CreateAsync(CreateMemberDto dto);

        Task<(bool Success, string? Error)>
            UpdateAsync(int id, UpdateMemberDto dto);

        Task<(bool Success, string? Error)>
            DeleteAsync(int id);
    }
}
