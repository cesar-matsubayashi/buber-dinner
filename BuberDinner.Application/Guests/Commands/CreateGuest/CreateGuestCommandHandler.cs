using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Guest;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandHandler
        : IRequestHandler<CreateGuestCommand, ErrorOr<Guest>>
    {
        private readonly IGuestRepository _guestRepository;

        public CreateGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<ErrorOr<Guest>> Handle(
            CreateGuestCommand request, 
            CancellationToken cancellationToken)
        {
            var guest = Guest.Create(
                request.FirstName,
                request.LastName,
                request.ProfileImage,
                request.UserId);

            await _guestRepository.AddAsync(guest);

            return guest;
        }
    }
}
