using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private const long MaxFileSize = 2 * 1024 * 1024; // 2 MB

        private static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

        private static readonly string[] AllowedContentTypes =
        {
            "image/jpeg",
            "image/png"
        };

        public FileService(IWebHostEnvironment environment,IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> SaveBookCoverAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException(
                    "Book cover image is required.");
            }

            if (file.Length > MaxFileSize)
            {
                throw new ArgumentException(
                    "Book cover image size must not exceed 2 MB.");
            }

            var extension =
                Path.GetExtension(file.FileName)
                    .ToLowerInvariant();

            if (!AllowedExtensions.Contains(extension))
            {
                throw new ArgumentException(
                    "Only JPG, JPEG and PNG images are allowed.");
            }

            if (!AllowedContentTypes.Contains(file.ContentType))
            {
                throw new ArgumentException(
                    "Invalid image content type.");
            }

            var uploadsFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "books");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName =
                $"{Guid.NewGuid()}{extension}";

            var filePath =
                Path.Combine(uploadsFolder, fileName);

            await using var stream =
                new FileStream(
                    filePath,
                    FileMode.Create);

            await file.CopyToAsync(stream);

            return fileName;
        }

        public void DeleteBookCover(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return;
            }

            var filePath = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "books",
                fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string GetBookCoverUrl(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            var request =
                _httpContextAccessor.HttpContext?.Request;

            if (request == null)
            {
                return string.Empty;
            }

            return $"{request.Scheme}://{request.Host}/uploads/books/{fileName}";
        }
    }
}
