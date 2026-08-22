using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class UserActivityLog
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Action { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? EntityName { get; set; }

        public int? EntityId { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [MaxLength(45)]
        public string? IpAddress { get; set; }

        // Navigation Property
        public ApplicationUser User { get; set; } = null!;
    }
}
