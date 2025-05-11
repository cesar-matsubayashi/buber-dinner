using BuberDinner.Application.Dinners.Commands.CreateReservation;
using BuberDinner.Application.Dinners.Commands.UpdateReservation;
using BuberDinner.Domain.Dinner.Entities;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Dinners.Extensions
{
    public static partial class ReservationExtensions
    {
        public static void ValidateCreatedFrom(
            this Reservation reservation, 
            CreateReservationCommand command)
        {
            reservation.GuestCount.Should().Be(command.GuestCount);
            reservation.GuestId.Should().Be(command.GuestId);
            reservation.BillId.Should().Be(command.BillId);
            reservation.Status.Should().Be(ReservationStatus.Reserved);
        }

        public static void ValidateUpdatedFrom(
            this Reservation reservation,
            UpdateReservationCommand command)
        {
            reservation.GuestCount.Should().Be(command.GuestCount);
            reservation.BillId.Should().Be(command.BillId);
            reservation.Status.Should().Be(command.ReservationStatus);
            reservation.ArrivalDateTime.Should().Be(command.ArrivalDateTime);

        }
    }
}
