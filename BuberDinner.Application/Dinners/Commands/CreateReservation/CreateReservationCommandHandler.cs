using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Dinner.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateReservation
{
    public class CreateReservationCommandHandler
        : IRequestHandler<CreateReservationCommand, ErrorOr<Reservation>>
    {
        private readonly IDinnerRepository _dinnerRepository;

        public CreateReservationCommandHandler(IDinnerRepository dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }

        public async Task<ErrorOr<Reservation>> Handle(
            CreateReservationCommand request, 
            CancellationToken cancellationToken)
        {
            var dinner = await _dinnerRepository.GetAsync(request.DinnerId);

            if (dinner is null)
            {
                return Errors.Dinner.NotFound;
            }

            // todo: check guest existence

            dinner.AddReservation(
                request.GuestCount,
                request.GuestId,
                request.BillId);

            await _dinnerRepository.UpdateAsync(dinner);

            var reservation = dinner.Reservations.FirstOrDefault(
                r => r.GuestId == request.GuestId);

            return reservation!;
        }
    }
}
