using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateReservation
{
    public record CreateReservationCommand(
        DinnerId DinnerId,
        int GuestCount,
        GuestId GuestId,
        BillId BillId) : IRequest<ErrorOr<Reservation>>;
}
