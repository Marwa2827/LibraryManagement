using LibraryManagement.Models.Enums;

namespace LibraryManagement.DTOs.Borrowings
{
    public class BorrowingResponseDto
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int MemberId { get; set; }

        public string MemberCode { get; set; } = string.Empty;

        public string MemberName { get; set; } = string.Empty;

        public int BorrowedByUserId { get; set; }

        public string BorrowedByUserName { get; set; } = string.Empty;

        public DateTime BorrowedAt { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnedAt { get; set; }

        public int? ReturnedByUserId { get; set; }

        public string? ReturnedByUserName { get; set; }

        public BorrowingStatus Status { get; set; }
    }
}
