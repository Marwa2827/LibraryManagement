namespace LibraryManagement.DTOs.Members
{
    public class MemberResponseDto
    {
        public int Id { get; set; }

        public string MemberCode { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime JoinDate { get; set; }

        public bool IsActive { get; set; }
    }
}
