using FluentValidation;

namespace BuberDinner.Application.Guests.Commands.UpdateGuestRating
{
    public class UpdateGuestRatingCommandValidator
        : AbstractValidator<UpdateGuestRatingCommand>
    {
        public UpdateGuestRatingCommandValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
            RuleFor(g => g.GuestId).NotEmpty();
            RuleFor(g => g.Rating).NotEmpty();
        }
    }
}
