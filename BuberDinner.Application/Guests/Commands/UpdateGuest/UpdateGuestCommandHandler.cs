using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Guest;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandHandler
        : IRequestHandler<UpdateGuestCommand, ErrorOr<Guest>>
    {
        private readonly IGuestRepository _guestRepository;

        public UpdateGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<ErrorOr<Guest>> Handle(
            UpdateGuestCommand request, 
            CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetAsync(request.Id);

            if (guest is null)
            {
                return Errors.Guest.NotFound;
            }

            guest.Update(
                request.FirstName,
                request.LastName,
                request.ProfileImage);

            await _guestRepository.UpdateAsync(guest);

            return guest;
        }
    }
}
