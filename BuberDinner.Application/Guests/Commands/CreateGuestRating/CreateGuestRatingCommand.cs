using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Commands.CreateGuestRating
{
    public record CreateGuestRatingCommand(
        GuestId GuestId,
        HostId HostId,
        DinnerId DinnerId,
        Rating Rating) : IRequest<ErrorOr<GuestRating>>;
}
