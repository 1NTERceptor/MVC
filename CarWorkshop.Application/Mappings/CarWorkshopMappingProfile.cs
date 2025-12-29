using AutoMapper;
using CarWorkshop.Application.Models;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopInputModel, CarWorkshopUnit>()
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails
                {
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }))
                .ForMember(dest => dest.EncodedName, opt => opt.MapFrom(src => src.Name.ToLower().Replace(" ", "-")));
        }
    }
}
