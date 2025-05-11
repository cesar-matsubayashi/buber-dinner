using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Commands.CreateReservation;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.Dinners.Extensions;
using BuberDinner.Domain.Dinner;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Commands.CreateReservation
{
    public class CreateReservationCommandHandlerTest
    {
        private readonly CreateReservationCommandHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;
        private static readonly List<Dinner> _dinners = new();

        public CreateReservationCommandHandlerTest()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new CreateReservationCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateReservationCommand))]
        public async Task HandleCreateReservationCommand_WhenReservationIdValid_ShouldCreateAndReturnReservation(
            CreateReservationCommand createReservationCommand)
        {
            var dinner = _dinners.First(d => d.Id == createReservationCommand.DinnerId);
            _mockRepository.Setup(r => r.GetAsync(createReservationCommand.DinnerId))
                .ReturnsAsync(dinner);

            var result = await _handler.Handle(createReservationCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createReservationCommand);
            dinner.Reservations.Should().HaveCount(1);
            dinner.Reservations.Should().ContainEquivalentOf(result.Value);
            _mockRepository.Verify(d => d.GetAsync(createReservationCommand.DinnerId), Times.Once);
            _mockRepository.Verify(d => d.UpdateAsync(dinner), Times.Once);
        }

        private static void CreateDinners()
        {
            _dinners.Add(CreateDinnerUtils.CreateDinner());

            _dinners.Add(CreateDinnerUtils.CreateDinner(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc),
                price: CreateDinnerUtils.CreatePrice(15.99m)));
        }

        public static IEnumerable<object[]> ValidCreateReservationCommand()
        {
            CreateDinners();

            yield return new[]
            {
                new CreateReservationCommand(
                    _dinners[0].Id,
                    2,
                    Constants.Guest.Id1,
                    Constants.Bill.Id1)
            };

            yield return new[]
            {
                new CreateReservationCommand(
                    _dinners[1].Id,
                    4,
                    Constants.Guest.Id2,
                    Constants.Bill.Id2)
            };
        }
    }
}
