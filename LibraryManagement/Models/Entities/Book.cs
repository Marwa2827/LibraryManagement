using LibraryManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

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

        public int PublicationYear { get; set; }

        [MaxLength(500)]
        public string? CoverImage { get; set; }

        public BookStatus Status { get; set; } = BookStatus.Available;

        // Foreign Keys
        public int PublisherId { get; set; }

        public int CategoryId { get; set; }

        // Navigation Properties
        public Publisher Publisher { get; set; } = null!;

        public Category Category { get; set; } = null!;

        public ICollection<BookAuthor> BookAuthors { get; set; }
            = new List<BookAuthor>();

        public ICollection<Borrowing> Borrowings { get; set; }
            = new List<Borrowing>();
    }
}
