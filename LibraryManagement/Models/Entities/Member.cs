using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string MemberCode { get; set; } = string.Empty;

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

        public DateTime JoinDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Navigation Property
        public ICollection<Borrowing> Borrowings { get; set; }
            = new List<Borrowing>();
    }
}
