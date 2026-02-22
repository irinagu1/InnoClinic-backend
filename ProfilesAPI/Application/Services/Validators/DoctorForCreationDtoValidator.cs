using FluentValidation;
using Shared.Dtos;

namespace Services.Validators;

public class DoctorForCreationDtoValidator : AbstractValidator<DoctorForCreationDto>
{
    public DoctorForCreationDtoValidator()
    {
        RuleFor(d => d.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty");
        
        RuleFor(d => d.LastName)
            .NotEmpty()
            .WithMessage("First name cannot be empty");   
        
        RuleFor(d => d.Status)
            .NotEmpty()
            .Must(s => StatusValues.Statuses.Contains(s))
            .WithMessage("Cant set such status");
    }
}


public static class StatusValues
{
    public static List<string> Statuses =
        ["At work", 
         "On vacation",
         "Sick day",
         "Sick leave",
         "Self-isloation",
         "Leave without pay",
         "Inactive"
        ];
}