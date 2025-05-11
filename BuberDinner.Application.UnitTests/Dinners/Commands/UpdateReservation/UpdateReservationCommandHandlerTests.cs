using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Commands.CreateReservation;
using BuberDinner.Application.Dinners.Commands.UpdateReservation;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.Dinners.Extensions;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.Entities;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandlerTests
    {
        private readonly UpdateReservationCommandHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;
        private static readonly List<Dinner> _dinners = new();

        public UpdateReservationCommandHandlerTests()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new UpdateReservationCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateReservationCommands))]
        public async Task HandlerUpdateReservationCommand_WhenUpdateIsValid_ShouldUpdateAndReturnReservation(
            UpdateReservationCommand updateReservationCommand)
        {
            var dinner = _dinners.First(d => d.Id == updateReservationCommand.DinnerId);
            _mockRepository.Setup(r => r.GetAsync(updateReservationCommand.DinnerId))
                .ReturnsAsync(dinner);

            var result = await _handler.Handle(updateReservationCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateReservationCommand);
            dinner.Reservations.Should().HaveCount(2);
            dinner.Reservations.Should().ContainEquivalentOf(result.Value);
            _mockRepository.Verify(d => d.GetAsync(updateReservationCommand.DinnerId), Times.Once);
            _mockRepository.Verify(d => d.UpdateAsync(dinner), Times.Once);
        }

        private static void CreateDinners()
        {
            _dinners.Add(CreateDinnerUtils.CreateDinner(reservation: true));

            _dinners.Add(CreateDinnerUtils.CreateDinner(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc),
                price: CreateDinnerUtils.CreatePrice(15.99m),
                reservation: true));
        }

        public static IEnumerable<object[]> ValidUpdateReservationCommands()
        {
            CreateDinners();

            yield return new[]
            {
                new UpdateReservationCommand(
                    _dinners[0].Reservations.First().Id,
                    _dinners[0].Id,
                    3,
                    Constants.Bill.Id2,
                    ReservationStatus.PendingGuestConfirmation,
                    Constants.Reservation.ArrivalDateTimeFromStartDateTime(_dinners[0].StartDateTime))
            };

            yield return new[]
            {
                new UpdateReservationCommand(
                    _dinners[0].Reservations.First().Id,
                    _dinners[0].Id,
                    3,
                    Constants.Bill.Id2,
                    ReservationStatus.Cancelled,
                    null)
            };
        }
    }
}
