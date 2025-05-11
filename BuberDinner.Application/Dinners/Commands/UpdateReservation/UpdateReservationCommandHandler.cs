using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Dinner.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler
        : IRequestHandler<UpdateReservationCommand, ErrorOr<Reservation>>
    {
        private readonly IDinnerRepository _dinnerRepository;

        public UpdateReservationCommandHandler(IDinnerRepository dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }

        public async Task<ErrorOr<Reservation>> Handle(
            UpdateReservationCommand request,
            CancellationToken cancellationToken)
        {
            var dinner = await _dinnerRepository.GetAsync(request.DinnerId);

            if (dinner is null)
            {
                return Errors.Dinner.NotFound;
            }

            var reservation = dinner.Reservations.FirstOrDefault(
                r => r.Id == request.Id);

            if (reservation is null)
            {
                return Errors.Reservation.NotFound;
            }

            dinner.UpdateReservation(
                request.Id,
                request.GuestCount,
                request.BillId,
                request.ReservationStatus,
                request.ArrivalDateTime);

            await _dinnerRepository.UpdateAsync(dinner);

            return reservation;
        }
    }
}
