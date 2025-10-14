using System.Linq;
using System.Threading.Tasks;
using BorrowITEquip.Data;
using Microsoft.EntityFrameworkCore;

namespace BorrowITEquip.Models.Repositories
{
    public class EFRequestRepository : IRequestRepository
    {
        private readonly FastEquipmentContext _db;
        public EFRequestRepository(FastEquipmentContext db) { _db = db; }

        public IQueryable<Request> GetAll() =>
            _db.Requests.AsNoTracking().OrderByDescending(r => r.CreatedAt);

        public IQueryable<Request> GetPending() =>
            GetAll().Where(r => r.Status == RequestStatus.Pending);

        public Task<Request?> FindByIdAsync(int id) =>
            _db.Requests.Include(r => r.Equipment).FirstOrDefaultAsync(r => r.Id == id);

        public async Task AddAsync(Request r)
        {
            _db.Requests.Add(r);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, RequestStatus status)
        {
            var req = await _db.Requests.FindAsync(id);
            if (req == null) return;
            req.Status = status;
            await _db.SaveChangesAsync();
        }
    }
}
