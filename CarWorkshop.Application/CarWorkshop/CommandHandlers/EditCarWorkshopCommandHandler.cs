using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Application.CarWorkshop.CommandHandlers
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;
        public EditCarWorkshopCommandHandler(
            ICarWorkshopRepository carWorkshopRepository,
            IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetById(request.Id);

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.Street = request.Street;
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode; 

            await _carWorkshopRepository.Commit();
        }
    }
}
