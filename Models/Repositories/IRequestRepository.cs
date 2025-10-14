using System.Linq;
using System.Threading.Tasks;

namespace BorrowITEquip.Models.Repositories
{
    public interface IRequestRepository
    {
        IQueryable<Request> GetAll();
        IQueryable<Request> GetPending();
        Task<Request?> FindByIdAsync(int id);
        Task AddAsync(Request r);
        Task UpdateStatusAsync(int id, RequestStatus status);
    }
}
