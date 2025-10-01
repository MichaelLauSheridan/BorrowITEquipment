using System.Collections.Generic;

namespace BorrowITEquip.Models.Repositories
{
    public static class EquipmentRepository
    {
        private static readonly List<Equipment> _items = new()
        {
            new Equipment { Id = 1, Type = EquipmentType.Laptop, Description = "Dell Laptop", IsAvailable = true },
            new Equipment { Id = 2, Type = EquipmentType.Laptop, Description = "Mac Laptop", IsAvailable = false },
            new Equipment { Id = 3, Type = EquipmentType.Tablet, Description = "iPad (10th gen)", IsAvailable = true },
            new Equipment { Id = 4, Type = EquipmentType.Phone, Description = "iPhone 12", IsAvailable = true },
            new Equipment { Id = 5, Type = EquipmentType.Another, Description = "USB-C Cable", IsAvailable = false },
        };

        public static IEnumerable<Equipment> GetAll() => _items;
    }
}
