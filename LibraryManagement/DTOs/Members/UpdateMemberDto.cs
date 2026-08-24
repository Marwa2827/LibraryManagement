using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Members
{
    public class UpdateMemberDto
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public bool IsActive { get; set; }
    }
}
