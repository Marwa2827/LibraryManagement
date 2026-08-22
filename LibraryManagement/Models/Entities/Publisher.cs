using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        // Navigation Property
        public ICollection<Book> Books { get; set; }
            = new List<Book>();
    }
}
