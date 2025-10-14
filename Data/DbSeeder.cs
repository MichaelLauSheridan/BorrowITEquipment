using System.Linq;
using BorrowITEquip.Models;

namespace BorrowITEquip.Data
{
    public static class DbSeeder
    {
        public static void Seed(FastEquipmentContext context)
        {
            // Ensure DB is created
            context.Database.EnsureCreated();

            // If there’s already data, skip seeding
            if (context.Equipment.Any()) return;

            var items = new[]
            {
                new Equipment { Type = EquipmentType.Laptop, Description = "Dell Latitude", IsAvailable = true },
                new Equipment { Type = EquipmentType.Laptop, Description = "Lenovo ThinkPad", IsAvailable = false },
                new Equipment { Type = EquipmentType.Tablet, Description = "iPad (10th Gen)", IsAvailable = true },
                new Equipment { Type = EquipmentType.Tablet, Description = "Samsung Galaxy Tab S7", IsAvailable = false },
                new Equipment { Type = EquipmentType.Phone, Description = "iPhone 12", IsAvailable = true },
                new Equipment { Type = EquipmentType.Phone, Description = "Google Pixel 7", IsAvailable = false },
                new Equipment { Type = EquipmentType.Another, Description = "USB-C Docking Station", IsAvailable = true },
                new Equipment { Type = EquipmentType.Another, Description = "Wireless Mouse and Keyboard Set", IsAvailable = true }
            };

            context.Equipment.AddRange(items);
            context.SaveChanges();
        }
    }
}
