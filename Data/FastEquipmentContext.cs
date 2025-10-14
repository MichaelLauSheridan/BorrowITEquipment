using BorrowITEquip.Models;
using Microsoft.EntityFrameworkCore;

namespace BorrowITEquip.Data
{
    public class FastEquipmentContext : DbContext
    {
        public FastEquipmentContext(DbContextOptions<FastEquipmentContext> options)
            : base(options) { }

        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Request> Requests => Set<Request>();
    }
}
