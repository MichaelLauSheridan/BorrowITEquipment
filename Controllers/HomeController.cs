using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BorrowITEquip.Models;
using BorrowITEquip.Models.Repositories;
using BorrowITEquip.Models.ViewModels;

namespace BorrowITEquip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEquipmentRepository _equip;
        private readonly IRequestRepository _req;

        public HomeController(
            ILogger<HomeController> logger,
            IEquipmentRepository equip,
            IRequestRepository req)
        {
            _logger = logger;
            _equip = equip;
            _req = req;
        }

        public IActionResult Index() => View();

        [HttpGet("/AllEquipment")]
        public IActionResult AllEquipment()
        {
            var items = _equip.GetAll().ToList();
            return View(items);
        }

        [HttpGet("/AvailableEquipment")]
        public IActionResult AvailableEquipment()
        {
            var items = _equip.GetAvailable().ToList();
            return View(items);
        }

        [HttpGet("/EquipmentRequest")]
        public IActionResult EquipmentForm()
        {
            var vm = new RequestFormVm
            {
                EquipmentOptions = _equip.GetAvailable().ToList()
            };
            return View(vm);
        }

        [HttpPost("/EquipmentRequest")]
        public async Task<IActionResult> EquipmentForm(RequestFormVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.EquipmentOptions = _equip.GetAvailable().ToList();
                return View(vm);
            }

            var chosen = await _equip.FindByIdAsync(vm.EquipmentId!.Value);
            if (chosen == null)
            {
                ModelState.AddModelError(nameof(vm.EquipmentId), "Selected equipment not found.");
                vm.EquipmentOptions = _equip.GetAvailable().ToList();
                return View(vm);
            }

            var request = new Request
            {
                Name = vm.Name,
                Email = vm.Email,
                Phone = vm.Phone,
                Role = vm.Role!.Value,
                DurationDays = vm.DurationDays!.Value,
                EquipmentId = vm.EquipmentId!.Value,
                Status = RequestStatus.Pending
            };

            await _req.AddAsync(request);
            return RedirectToAction(nameof(Confirmation), new { id = request.Id });
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var req = await _req.FindByIdAsync(id);
            if (req == null) return RedirectToAction(nameof(EquipmentForm));
            return View(req);
        }

        [HttpGet("/Requests")]
        public IActionResult Requests()
        {
            var rows = _req.GetAll()
                .Join(_equip.GetAll(), r => r.EquipmentId, e => e.Id,
                    (r, e) => new RequestRowVm
                    {
                        Id = r.Id,
                        Equipment = $"{e.Description} ({e.Type})",
                        Name = r.Name,
                        Role = r.Role,
                        DurationDays = r.DurationDays,
                        Status = r.Status
                    })
                .ToList();

            return View(rows);
        }

        [HttpPost("/Requests/{id}/accept")]
        public async Task<IActionResult> Accept(int id)
        {
            await _req.UpdateStatusAsync(id, RequestStatus.Accepted);
            return RedirectToAction(nameof(Requests));
        }

        [HttpPost("/Requests/{id}/deny")]
        public async Task<IActionResult> Deny(int id)
        {
            await _req.UpdateStatusAsync(id, RequestStatus.Denied);
            return RedirectToAction(nameof(Requests));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
