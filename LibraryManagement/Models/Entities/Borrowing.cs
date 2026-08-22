using LibraryManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class Borrowing
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int MemberId { get; set; }

        [Required]
        public int BorrowedByUserId { get; set; }

        public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;

        public DateTime DueDate { get; set; }

        public DateTime? ReturnedAt { get; set; }

        public int? ReturnedByUserId { get; set; }

        public BorrowingStatus Status { get; set; } = BorrowingStatus.Borrowed;

        // Navigation Properties
        public Book Book { get; set; } = null!;

        public Member Member { get; set; } = null!;

        public ApplicationUser BorrowedByUser { get; set; } = null!;

        public ApplicationUser? ReturnedByUser { get; set; }
    }
}
