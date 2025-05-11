using FluentValidation;

namespace BuberDinner.Application.Dinners.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(r => r.DinnerId).NotEmpty();
            RuleFor(r => r.GuestCount).NotEmpty();
            RuleFor(r => r.GuestId).NotEmpty();
            RuleFor(r => r.BillId).NotEmpty();
        }
    }
}
