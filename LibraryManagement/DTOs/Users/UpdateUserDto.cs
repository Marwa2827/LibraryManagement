using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Users
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
