using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services.Implementations
{
    public class UserActivityLogService : IUserActivityLogService
    {
        private readonly ApplicationDbContext _context;

        public UserActivityLogService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(
            int userId,
            string action,
            string? entityName = null,
            int? entityId = null,
            string? ipAddress = null)
        {
            var log = new UserActivityLog
            {
                UserId = userId,
                Action = action,
                EntityName = entityName,
                EntityId = entityId,
                IpAddress = ipAddress,
                Timestamp = DateTime.UtcNow
            };

            _context.UserActivityLogs.Add(log);

            await _context.SaveChangesAsync();
        }
    }
}
