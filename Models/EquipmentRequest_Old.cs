// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.ComponentModel.DataAnnotations;
// namespace BorrowITEquip.Models
// {
//     public enum Role
//     {
//         Student = 0,
//         Professor = 1
//     }
//     public enum EquipmentType
//     {
//         Laptop = 0,
//         Phone = 1,
//         Tablet = 2,
//         Another = 3
//     }
//     public class EquipmentRequest
//     {
//         [Required(ErrorMessage = "Please enter your name")]
//         public string? Name { get; set; }
//         [Required(ErrorMessage = "Please enter your email")]
//         [EmailAddress(ErrorMessage = "Please enter a valid email address")]
//         public string? Email { get; set; }
//         [Required(ErrorMessage ="A phone number is required")]
//         [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone must be in the format xxx-xxx-xxxx")]
//         public string? Phone { get; set; }
//         [Required(ErrorMessage = "Please select your role")]
//         public Role? Role { get; set; }
//         [Required(ErrorMessage = "Please select your equipment type")]
//         public EquipmentType? EquipmentType { get; set; }
//         public string? RequestDetails { get; set; }
//         [Required(ErrorMessage = "Please enter the duration")]
//         [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
//         public int Duration { get; set; }

//         public int Id { get; set; }
//     }
// }