using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.DeleteGuest
{
    public record DeleteGuestCommand(GuestId Id) : IRequest<ErrorOr<Deleted>>;
}
