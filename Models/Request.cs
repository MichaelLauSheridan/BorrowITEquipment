using System.ComponentModel.DataAnnotations;

namespace BorrowITEquip.Models
{
    public class Request
    {
        public int Id { get; set; }

        // Requester info
        [Required, StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Use format: 905-123-4567")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public Role Role { get; set; }

        // Borrowing details
        [Required, Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int DurationDays { get; set; }

        [Required]
        public int EquipmentId { get; set; }  // foreign key
        public Equipment? Equipment { get; set; }  // navigation property

        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
