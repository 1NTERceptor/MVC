using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Application.Models
{
    public class CarWorkshopInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Please insert description")]
        public string? Description { get; set; }
        public string? About { get; set; }

        [StringLength(12, MinimumLength = 8)]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? EncodedName { get; set; }
    }

    public class CarWorkshopInputModelValidation : AbstractValidator<CarWorkshopInputModel>
    {
        public CarWorkshopInputModelValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 20);
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Please insert description");
            RuleFor(x => x.PhoneNumber)
                .Length(8, 12)
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Phone number must be between 8 and 12 characters.");
        }
    }
}
