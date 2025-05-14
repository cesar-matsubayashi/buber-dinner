using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Guests.Queries.GetGuest
{
    public record GetGuestQuery(GuestId Id) : IRequest<ErrorOr<Guest>>;
}
