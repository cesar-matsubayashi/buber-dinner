using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.UpdateReservation
{
    public record UpdateReservationCommand(
        ReservationId Id,
        DinnerId DinnerId,
        int GuestCount,
        BillId BillId,
        ReservationStatus ReservationStatus,
        DateTime? ArrivalDateTime) : IRequest<ErrorOr<Reservation>>;
}
