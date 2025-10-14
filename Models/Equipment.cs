using System.ComponentModel.DataAnnotations;

namespace BorrowITEquip.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public EquipmentType Type { get; set; }

        [Required, StringLength(200, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsAvailable { get; set; }
    }
}
