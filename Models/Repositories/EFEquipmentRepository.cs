using System.Linq;
using System.Threading.Tasks;
using BorrowITEquip.Data;
using Microsoft.EntityFrameworkCore;

namespace BorrowITEquip.Models.Repositories
{
    public class EFEquipmentRepository : IEquipmentRepository
    {
        private readonly FastEquipmentContext _db;
        public EFEquipmentRepository(FastEquipmentContext db) { _db = db; }

        public IQueryable<Equipment> GetAll() =>
            _db.Equipment.AsNoTracking().OrderBy(e => e.Id);

        public IQueryable<Equipment> GetAvailable() =>
            GetAll().Where(e => e.IsAvailable);

        public Task<Equipment?> FindByIdAsync(int id) =>
            _db.Equipment.FindAsync(id).AsTask();

        public async Task AddAsync(Equipment item)
        {
            _db.Equipment.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment item)
        {
            _db.Equipment.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
