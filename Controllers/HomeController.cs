using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BorrowITEquip.Models;
using BorrowITEquip.Models.Repositories;
using System.Linq;

namespace BorrowITEquip.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("/Requests")]
    public IActionResult Requests()
    {
    var items = Repository.Requests.OrderByDescending(r => r.Id).ToList();
    return View(items);
    }
    [HttpGet("/AllEquipment")]
    public IActionResult AllEquipment()
    {
        var items = BorrowITEquip.Models.Repositories.EquipmentRepository.GetAll();
        return View(items);
    }
    [HttpGet("/AvailableEquipment")]
    public IActionResult AvailableEquipment()
    {
        var items = EquipmentRepository.GetAll().Where(e => e.IsAvailable);
        return View(items);
    }
    [HttpGet("/EquipmentRequest")]
    public IActionResult EquipmentForm()
    {
        return View(new EquipmentRequest());
    }
    [HttpPost("/EquipmentRequest")]
    public IActionResult EquipmentForm(EquipmentRequest model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        Repository.AddRequest(model);

        return RedirectToAction(nameof(Confirmation), new { id = model.Id });
    }
    public IActionResult Confirmation(int id)
    {
        var req = Repository.Requests.FirstOrDefault(r => r.Id == id);
        if (req is null) return RedirectToAction(nameof(EquipmentForm));
        return View(req);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
