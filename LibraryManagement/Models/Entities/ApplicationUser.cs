using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<Borrowing> BorrowingsMade { get; set; }
            = new List<Borrowing>();

        public ICollection<Borrowing> ReturnsMade { get; set; }
            = new List<Borrowing>();

        public ICollection<UserActivityLog> ActivityLogs { get; set; }
            = new List<UserActivityLog>();
    }
}
