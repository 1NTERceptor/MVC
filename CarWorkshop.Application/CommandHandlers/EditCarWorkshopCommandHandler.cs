using AutoMapper;
using CarWorkshop.Application.Commands;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Application.CommandHandlers
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand, int>
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

        public async Task<int> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<CarWorkshopUnit>(request);

            carWorkshop.EncodeName();

            return await _carWorkshopRepository.Edit(carWorkshop);
        }
    }
}
