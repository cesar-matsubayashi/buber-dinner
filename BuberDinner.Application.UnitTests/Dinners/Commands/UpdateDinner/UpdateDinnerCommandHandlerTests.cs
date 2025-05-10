using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Commands.DeleteDinner;
using BuberDinner.Application.Dinners.Commands.UpdateDinner;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Dinners.Extensions;
using BuberDinner.Domain.Dinner;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Commands.UpdateDinner
{
    public class UpdateDinnerCommandHandlerTests
    {
        private readonly UpdateDinnerCommandHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;
        private static readonly List<Dinner> _dinners = new();

        public UpdateDinnerCommandHandlerTests()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new UpdateDinnerCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateDinnerCommands))]
        public async Task HandleUpdateDinnerCommand_WhenUpdateIsValid_ShouldUpdateAndReturnDinner(
            UpdateDinnerCommand updateDinnerCommand)
        {
            var dinner = _dinners.First(m => m.Id == updateDinnerCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(updateDinnerCommand.Id))
                .ReturnsAsync(dinner);

            var result = await _handler.Handle(updateDinnerCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateDinnerCommand);
            _mockRepository.Verify(m => m.GetAsync(updateDinnerCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(dinner), Times.Once);
        }

        private static void CreateDinners()
        {
            _dinners.Add(CreateDinnerUtils.CreateDinner());

            _dinners.Add(CreateDinnerUtils.CreateDinner(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc)));

            _dinners.Add(CreateDinnerUtils.CreateDinner(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc),
                price: CreateDinnerUtils.CreatePrice(15.99m)));
        }

        public static IEnumerable<object[]> ValidUpdateDinnerCommands()
        {
            CreateDinners();

            yield return new[] { UpdateDinnerCommandUtils.UpdateCommand(_dinners[0].Id) };

            yield return new[]
            {
                UpdateDinnerCommandUtils.UpdateCommand(
                    id: _dinners[1].Id,
                    start: new DateTime(2025, 5, 15, 20, 0, 0, DateTimeKind.Utc))
            };

            yield return new[]
            {
                UpdateDinnerCommandUtils.UpdateCommand(
                    id: _dinners[2].Id,
                    start: new DateTime(2025, 5, 11, 18, 0, 0, DateTimeKind.Utc),
                    price: UpdateDinnerCommandUtils.UpdatePriceCommand(15.99m))
            };
        }
    }
}
