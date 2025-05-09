using BuberDinner.Application.Dinners.Commands.CreateDinner;
using FluentValidation;

public class CreateDinnerCommandValidator : AbstractValidator<CreateDinnerCommand>
{
    public CreateDinnerCommandValidator()
    {
        RuleFor(d => d.HostId).NotEmpty();
        RuleFor(d => d.Name).NotEmpty();
        RuleFor(d => d.Description).NotEmpty();
        RuleFor(d => d.StartDateTime).NotEmpty();
        RuleFor(d => d.EndDateTime).NotEmpty();
        RuleFor(d => d.IsPublic).NotEmpty();
        RuleFor(d => d.MaxGuests).NotEmpty();
        RuleFor(d => d.Price).NotEmpty()
            .SetValidator(new CreatePriceCommandValidator()); 
        RuleFor(d => d.MenuId).NotEmpty();
        RuleFor(d => d.ImageUrl).NotEmpty();
        RuleFor(d => d.Location).NotEmpty()
            .SetValidator(new CreateLocationCommandValidator());
    }
}

public class CreatePriceCommandValidator : AbstractValidator<CreatePriceCommand>
{
    public CreatePriceCommandValidator()
    {
        RuleFor(p => p.Amount).NotEmpty();
        RuleFor(p => p.Currency).NotEmpty();
    }
}

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(l => l.Name).NotEmpty();
        RuleFor(l => l.Address).NotEmpty();
        RuleFor(l => l.Latitude).NotEmpty();
        RuleFor(l => l.Longitude).NotEmpty();
    }
}