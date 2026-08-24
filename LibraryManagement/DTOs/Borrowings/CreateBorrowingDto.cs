using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Borrowings
{
    public class CreateBorrowingDto
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
