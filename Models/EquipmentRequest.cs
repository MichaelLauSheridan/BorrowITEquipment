using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BorrowITEquip.Models
{
    public class EquipmentRequest
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone must be in the format xxx-xxx-xxxx")]
        public string? Phone { get; set; }
        [Required]
        public string? EquipmentType { get; set; }
        [Required]
        public string? RequestDetails { get; set; }
        [Required]
        public string? Duration { get; set; }
    }
}