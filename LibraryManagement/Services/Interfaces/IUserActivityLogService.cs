namespace LibraryManagement.Services.Interfaces
{
    public interface IUserActivityLogService
    {
        Task LogAsync(
            int userId,
            string action,
            string? entityName = null,
            int? entityId = null,
            string? ipAddress = null);
    }
}
