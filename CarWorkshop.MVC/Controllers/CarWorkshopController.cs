using CarWorkshop.Application.Commands;
using CarWorkshop.Application.Models;
using CarWorkshop.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;
        private readonly IMediator _mediator;
        public CarWorkshopController(ICarWorkshopService carWorkshopService, IMediator mediator)
        {
            _carWorkshopService = carWorkshopService;
            _mediator = mediator;
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

        [HttpGet]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _carWorkshopService.GetByEncodedname(encodedName);
            return View(dto);
        }        

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, CarWorkshopInputModel model)
        {
            var cmd = new EditCarWorkshopCommand
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                About = model.About,
                PhoneNumber = model.PhoneNumber,
                Street = model.Street,
                City = model.City,
                PostalCode = model.PostalCode
            };

            await _mediator.Send(cmd);
            return RedirectToAction(nameof(Details), new { encodedName = model.Name.ToLower().Replace(" ", "-") });
        }
    }
}
