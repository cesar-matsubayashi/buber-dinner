using BuberDinner.Domain.Guest;
using BuberDinner.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.CreateGuest
{
    public record CreateGuestCommand(
        string FirstName,
        string LastName,
        string ProfileImage,
        UserId UserId) : IRequest<ErrorOr<Guest>>;
}
