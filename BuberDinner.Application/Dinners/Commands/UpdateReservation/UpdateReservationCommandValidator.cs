using FluentValidation;

namespace BuberDinner.Application.Dinners.Commands.UpdateReservation
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.GuestCount).NotEmpty();
            RuleFor(r => r.BillId).NotEmpty();
            RuleFor(r => r.ReservationStatus).IsInEnum();
            RuleFor(r => r.ArrivalDateTime).NotEmpty();
        }
    }
}
