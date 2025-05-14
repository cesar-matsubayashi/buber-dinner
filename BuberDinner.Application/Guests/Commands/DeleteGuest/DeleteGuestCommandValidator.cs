using FluentValidation;

namespace BuberDinner.Application.Guests.Commands.DeleteGuest
{
    public class DeleteGuestCommandValidator : AbstractValidator<DeleteGuestCommand>
    {
        public DeleteGuestCommandValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
        }
    }
}
