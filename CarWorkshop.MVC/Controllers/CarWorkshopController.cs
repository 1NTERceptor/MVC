using CarWorkshop.Application.Models;
using CarWorkshop.Application.Services;
using CarWorkshop.Domain.Entities;
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
        public async Task<IActionResult> Details(int id)
        {
            await _carWorkshopService.Get(id);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopInputModel carWorkshopUnit)
        {
            int id = await _carWorkshopService.Creat(carWorkshopUnit);
            return RedirectToAction(nameof(Create));
        }
    }
}
