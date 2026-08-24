using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Books
{
    public class CreateBookDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Edition { get; set; }

        public string? Summary { get; set; }

        [Required]
        [MaxLength(50)]
        public string Language { get; set; } = string.Empty;

        [Range(1000, 9999)]
        public int PublicationYear { get; set; }

        public IFormFile? CoverImage { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public List<int> AuthorIds { get; set; } = new();
    }
}
