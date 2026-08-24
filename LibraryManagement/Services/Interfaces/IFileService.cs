namespace LibraryManagement.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveBookCoverAsync(IFormFile file);

        void DeleteBookCover(string? fileName);

        string GetBookCoverUrl(string? fileName);
    }
}
