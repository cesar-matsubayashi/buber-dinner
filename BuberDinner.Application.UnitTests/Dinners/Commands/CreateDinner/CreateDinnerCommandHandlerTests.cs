using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Dinners.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Commands.CreateDinner
{
    public class CreateDinnerCommandHandlerTests
    {
        private readonly CreateDinnerCommandHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;

        public CreateDinnerCommandHandlerTests()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new CreateDinnerCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateDinnerCommands))]
        public async Task HandleCreateDinnerCommand_WhenDinnerIsValid_ShouldCreateAndReturnDinner(
            CreateDinnerCommand createDinnerCommand)
        {
            var result = await _handler.Handle(createDinnerCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createDinnerCommand);
            _mockRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateDinnerCommands()
        {
            yield return new[] { CreateDinnerCommandUtils.CreateCommand() };

            yield return new[] 
            { 
                CreateDinnerCommandUtils.CreateCommand(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc)) 
            };

            yield return new[] 
            { 
                CreateDinnerCommandUtils.CreateCommand(
                    start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc),
                    price: CreateDinnerCommandUtils.CreatePriceCommand(15.99m)) 
            };
        }
    }
}
