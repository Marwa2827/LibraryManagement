using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Publishers
{
    public class PublisherDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }
    }
}
