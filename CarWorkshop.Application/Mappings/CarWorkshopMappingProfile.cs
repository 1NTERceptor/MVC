using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands;
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

            CreateMap<CarWorkshopUnit, CarWorkshopInputModel>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));

            CreateMap<CarWorkshopUnit, EditCarWorkshopCommand>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));

            CreateMap<EditCarWorkshopCommand, CarWorkshopUnit>()
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails
                {
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.EncodedName, opt => opt.Ignore());
        }
    }
}
