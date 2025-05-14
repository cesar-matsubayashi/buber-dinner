using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.DeleteGuest
{
    public class DeleteGuestCommandHandler
        : IRequestHandler<DeleteGuestCommand, ErrorOr<Deleted>>
    {
        private readonly IGuestRepository _guestRepository;

        public DeleteGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteGuestCommand request, 
            CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetAsync(request.Id);

            if (guest is null)
            {
                return Errors.Guest.NotFound;
            }

            await _guestRepository.DeleteAsync(guest);

            return new Deleted();
        }
    }
}
