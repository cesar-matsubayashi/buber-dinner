using FluentValidation;

namespace BuberDinner.Application.Guests.Commands.CreateGuestRating
{
    public class CreateGuestRatingCommandValidator 
        : AbstractValidator<CreateGuestRatingCommand>
    {
        public CreateGuestRatingCommandValidator()
        {
            RuleFor(g => g.GuestId).NotEmpty();
            RuleFor(g => g.HostId).NotEmpty();
            RuleFor(g => g.DinnerId).NotEmpty();
            RuleFor(g => g.Rating).NotEmpty();
        }
    }
}
