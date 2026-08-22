using LibraryManagement.Models.Entities;

namespace LibraryManagement.Services.Interfaces
{
    public interface IJwtService
    {
        Task<(string Token, DateTime ExpiresAt)> GenerateTokenAsync(ApplicationUser user);
    }
}
