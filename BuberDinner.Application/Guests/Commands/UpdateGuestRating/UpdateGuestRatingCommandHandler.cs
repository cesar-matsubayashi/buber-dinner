using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Guest.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.UpdateGuestRating
{
    public class UpdateGuestRatingCommandHandler
        : IRequestHandler<UpdateGuestRatingCommand, ErrorOr<GuestRating>>
    {
        private readonly IGuestRepository _guestRepository;

        public UpdateGuestRatingCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<ErrorOr<GuestRating>> Handle(
            UpdateGuestRatingCommand request, 
            CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetAsync(request.GuestId);

            if (guest is null)
            {
                return Errors.Guest.NotFound;
            }

            guest.UpdateGuestRating(
                request.Id,
                request.Rating);

            await _guestRepository.UpdateAsync(guest);

            var guestRating = guest.GuestRatings.FirstOrDefault(
                r => r.Id == request.Id);

            return guestRating!;
        }
    }
}
