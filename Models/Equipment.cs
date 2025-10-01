using System.ComponentModel.DataAnnotations;

namespace BorrowITEquip.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public EquipmentType Type { get; set; }  // reuses your enum

        [Required, StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
    }
}
