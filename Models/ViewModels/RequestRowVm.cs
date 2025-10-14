using BorrowITEquip.Models;

namespace BorrowITEquip.Models.ViewModels
{
    public class RequestRowVm
    {
        public int Id { get; set; }
        public string Equipment { get; set; } = "";
        public string Name { get; set; } = "";
        public Role Role { get; set; }
        public int DurationDays { get; set; }
        public RequestStatus Status { get; set; }
    }
}
