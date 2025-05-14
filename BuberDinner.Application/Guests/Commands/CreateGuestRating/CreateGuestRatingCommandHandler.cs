using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Guest.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.CreateGuestRating
{
    public class CreateGuestRatingCommandHandler
        : IRequestHandler<CreateGuestRatingCommand, ErrorOr<GuestRating>>
    {
        private readonly IGuestRepository _guestRepository;

        public CreateGuestRatingCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<ErrorOr<GuestRating>> Handle(
            CreateGuestRatingCommand request, 
            CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetAsync(request.GuestId);
            
            if (guest is null)
            {
                return Errors.Guest.NotFound;
            }

            guest.AddGuestRating(
                request.HostId,
                request.DinnerId,
                request.Rating);

            await _guestRepository.UpdateAsync(guest);

            var guestRating = guest.GuestRatings.FirstOrDefault(
                r => r.HostId == request.HostId && 
                r.DinnerId == request.DinnerId);

            return guestRating!;
        }
    }
}
