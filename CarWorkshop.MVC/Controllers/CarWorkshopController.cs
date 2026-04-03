using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.CarWorkshop.Queries;
using CarWorkshop.Application.Models;
using CarWorkshop.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarWorkshopController(ICarWorkshopService carWorkshopService, IMediator mediator, IMapper mapper)
        {
            _carWorkshopService = carWorkshopService;
            _mediator = mediator;
            _mapper = mapper;
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
            var query = new GetCarWorkshopByEncodednameQuery
            {
                EncodedName = encodedName
            };

            var carWorkshop = await _mediator.Send(query);

            var editCarWorkshopCommand = _mapper.Map<EditCarWorkshopCommand>(carWorkshop);

            return View(editCarWorkshopCommand);
        }        

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand cmd)
        {
            await _mediator.Send(cmd);
            return RedirectToAction(nameof(Details), new { encodedName = encodedName });
        }
    }
}
