using BuberDinner.Application.Dinners.Commands.UpdateDinner;
using FluentValidation;

public class UpdateDinnerCommandValidator : AbstractValidator<UpdateDinnerCommand>
{
    public UpdateDinnerCommandValidator()
    {
        RuleFor(d => d.Name).NotEmpty();
        RuleFor(d => d.Description).NotEmpty();
        RuleFor(d => d.StartDateTime).NotEmpty();
        RuleFor(d => d.EndDateTime).NotEmpty();
        RuleFor(d => d.IsPublic).NotEmpty();
        RuleFor(d => d.MaxGuests).NotEmpty();
        RuleFor(d => d.Price).NotEmpty()
            .SetValidator(new UpdatePriceCommandValidator());
        RuleFor(d => d.MenuId).NotEmpty();
        RuleFor(d => d.ImageUrl).NotEmpty();
        RuleFor(d => d.Location).NotEmpty()
            .SetValidator(new UpdateLocationCommandValidator());
    }
}

public class UpdatePriceCommandValidator : AbstractValidator<UpdatePriceCommand>
{
    public UpdatePriceCommandValidator()
    {
        RuleFor(p => p.Amount).NotEmpty();
        RuleFor(p => p.Currency).NotEmpty();
    }
}

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(l => l.Name).NotEmpty();
        RuleFor(l => l.Address).NotEmpty();
        RuleFor(l => l.Latitude).NotEmpty();
        RuleFor(l => l.Longitude).NotEmpty();
    }
}