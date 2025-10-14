using System.Linq;
using System.Threading.Tasks;

namespace BorrowITEquip.Models.Repositories
{
    public interface IEquipmentRepository
    {
        IQueryable<Equipment> GetAll();
        IQueryable<Equipment> GetAvailable();
        Task<Equipment?> FindByIdAsync(int id);
        Task AddAsync(Equipment item);
        Task UpdateAsync(Equipment item);
    }
}
