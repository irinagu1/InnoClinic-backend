using System.Collections.Frozen;
using System.Reflection;
using FluentValidation;
using OfficesApi.Domain;

namespace OfficesApi.Application.Offices.PartiallyUpdate;

public sealed class  PartiallyUpdateOfficeCommandValidator 
    : AbstractValidator<PartiallyUpdateOfficeCommand>
{
    private static FrozenSet<string> ForbiddenKeyNames =
         new[] {"Id", "id", "_id"}.ToFrozenSet();
    
    List<string> AcceptableKeyNames;

    public PartiallyUpdateOfficeCommandValidator()
    {
        AcceptableKeyNames = GetAcceptableKeyNames();

        RuleFor(comm => comm.id)
            .NotEmpty()
            .WithMessage("The id can't be empty");
        
        RuleFor(comm => comm.updates)
            .NotEmpty()
            .WithMessage("The updates dictionary can't be empty");
        
        RuleForEach(comm => comm.updates)
            .Must(item => !ForbiddenKeyNames.Contains(item.Key))
            .WithMessage("Entered a field that cannot be updated")
            .Must(item => AcceptableKeyNames.Contains(item.Key))
            .WithMessage("An update to a non-existent field for the office was introduced")
            .Must(item =>
            {                
                if(item.Key == "IsActive")
                {
                    if(item.Value.ToString() == "True" || item.Value.ToString() == "False")
                        return true;
                    return false;
                }
                return true;
            } )
            .WithMessage("For IsActive filed only boolean values are acceptable");
        
    }

    private List<string> GetAcceptableKeyNames()
    {
        List<string> Names = new();
    
        Type office = typeof(Office);
        
        var Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        
        var AllTypeFileds = office.GetFields(Flags);
        foreach(var field in AllTypeFileds)
            Names.Add(field.Name);

        var AllTypeProperties = office.GetProperties(Flags);
        foreach(var property in AllTypeProperties)
        {
            var propName = property.Name;
            if(!Names.Contains(propName))
                Names.Add(propName);
        }
        return Names;
    }
}
