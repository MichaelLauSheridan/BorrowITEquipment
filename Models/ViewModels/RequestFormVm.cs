using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BorrowITEquip.Models;

namespace BorrowITEquip.Models.ViewModels
{
    public class RequestFormVm
    {
        [Required, StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Use format: 905-123-4567")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public Role? Role { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int? DurationDays { get; set; }

        [Required]
        public int? EquipmentId { get; set; }

        public IEnumerable<Equipment>? EquipmentOptions { get; set; }
    }
}
