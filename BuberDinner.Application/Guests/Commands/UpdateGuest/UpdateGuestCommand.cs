using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.UpdateGuest
{
    public record UpdateGuestCommand(
        GuestId Id,
        string FirstName,
        string LastName,
        string ProfileImage) : IRequest<ErrorOr<Guest>>;
}
