using FluentValidation;

namespace BuberDinner.Application.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandValidator : AbstractValidator<UpdateGuestCommand>
    {
        public UpdateGuestCommandValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
            RuleFor(g => g.FirstName).NotEmpty();
            RuleFor(g => g.LastName).NotEmpty();
            RuleFor(g => g.ProfileImage).NotEmpty();
        }
    }
}
