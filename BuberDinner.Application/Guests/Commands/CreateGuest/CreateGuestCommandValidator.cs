using FluentValidation;

namespace BuberDinner.Application.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandValidator : AbstractValidator<CreateGuestCommand>
    {
        public CreateGuestCommandValidator()
        {
            RuleFor(g => g.FirstName).NotEmpty();
            RuleFor(g => g.LastName).NotEmpty();
            RuleFor(g => g.ProfileImage).NotEmpty();
            RuleFor(g => g.UserId).NotEmpty();
        }
    }
}
