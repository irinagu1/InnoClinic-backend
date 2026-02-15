using FluentValidation;

namespace OfficesApi.Application.Offices.Create;
public sealed class OfficeCreateValidator : AbstractValidator<OfficeCreate>
{
    public OfficeCreateValidator()
    {
        RuleFor(dto => dto.City)
            .NotEmpty()
            .WithMessage("The city can't be empty")
            .MinimumLength(1)
            .MaximumLength(100)
            .WithMessage("The city length should be more than 1 and less than 100 symbols");
    
        RuleFor(dto => dto.Street)
            .NotEmpty()
            .WithMessage("The street can't be empty")
            .MinimumLength(1)
            .MaximumLength(100)
            .WithMessage("The street length should be more than 1 and less than 100 symbols");

        RuleFor(dto => dto.HouseNumber)
            .NotEmpty()
            .WithMessage("The house number can't be empty");

        RuleFor(dto => dto.OfficeNumber)
            .NotEmpty()
            .WithMessage("The office number can't be empty");

        RuleFor(dto => dto.RegistryPhoneNumber)
            .NotEmpty()
            .WithMessage("The registry phone number can't be empty");
    }
}