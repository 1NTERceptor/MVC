using CarWorkshop.Application.Models;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;
        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carWorkshop = await _carWorkshopService.GetAll();
            return View(carWorkshop);
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _carWorkshopService.GetByEncodedname(encodedName);
            return View(dto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopInputModel carWorkshopUnit)
        {
            if (!ModelState.IsValid)
            {
                return View(carWorkshopUnit);
            }
            int id = await _carWorkshopService.Creat(carWorkshopUnit);
            return RedirectToAction(nameof(Index));
        }
    }
}
