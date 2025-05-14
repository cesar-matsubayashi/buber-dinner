using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Guest;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Queries.GetGuest
{
    public class GetGuestQueryHandler
        : IRequestHandler<GetGuestQuery, ErrorOr<Guest>>
    {
        private readonly IGuestRepository _guestRepository;

        public GetGuestQueryHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<ErrorOr<Guest>> Handle(
            GetGuestQuery request, 
            CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetAsync(request.Id);

            if (guest is null)
            {
                return Errors.Guest.NotFound;
            }

            return guest;
        }
    }
}
