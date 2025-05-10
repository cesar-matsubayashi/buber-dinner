using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Commands.DeleteDinner;
using BuberDinner.Application.Menus.Commands.DeleteMenu;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Domain.Dinner;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Commands.DeleteDinner
{
    public class DeleteDinnerCommandHandlerTests
    {
        private readonly DeleteDinnerCommandHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;
        private static readonly List<Dinner> _dinners = new();

        public DeleteDinnerCommandHandlerTests()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new DeleteDinnerCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidDeleteDinnerQuery))]
        public async Task HandleDeleteDinnerCommand_WhenDinnerExists_ShoulDeleteDinnerAndReturnNoContent(
            DeleteDinnerCommand deleteDinnerCommand)
        {
            var dinner = _dinners.First(m => m.Id == deleteDinnerCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(deleteDinnerCommand.Id))
                .ReturnsAsync(dinner);

            var result = await _handler.Handle(deleteDinnerCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Deleted>();
            _mockRepository.Verify(m => m.GetAsync(deleteDinnerCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.DeleteAsync(deleteDinnerCommand.Id), Times.Once);
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

        public static IEnumerable<object[]> ValidDeleteDinnerQuery()
        {
            CreateDinners();

            foreach (var dinner in _dinners)
            {
                yield return new[] { new DeleteDinnerCommand(dinner.Id) };
            }
        }
    }
}
