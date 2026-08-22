using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Authors
{
    public class AuthorDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

    }
}
