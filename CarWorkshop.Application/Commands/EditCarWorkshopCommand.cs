using FluentValidation;
using MediatR;

namespace CarWorkshop.Application.Commands
{
    public class EditCarWorkshopCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? About { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
    }

    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
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
