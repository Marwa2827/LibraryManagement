using LibraryManagement.Models.Enums;

namespace LibraryManagement.DTOs.Books
{
    public class BookResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public string? Edition { get; set; }

        public string? Summary { get; set; }

        public string Language { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        public string? CoverImage { get; set; }

        public BookStatus Status { get; set; }

        public int PublisherId { get; set; }

        public string PublisherName { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public List<int> AuthorIds { get; set; } = new();

        public List<string> AuthorNames { get; set; } = new();
    }
}
