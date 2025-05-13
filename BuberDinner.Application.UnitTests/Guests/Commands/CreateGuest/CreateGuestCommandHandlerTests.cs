using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Guests.Commands.CreateGuest;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.Guests.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandHandlerTests
    {
        private readonly CreateGuestCommandHandler _handler;
        private readonly Mock<IGuestRepository> _mockRepository;

        public CreateGuestCommandHandlerTests()
        {
            _mockRepository = new Mock<IGuestRepository>();
            _handler = new CreateGuestCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateGuestCommands))]
        public async Task HandlerCreateGuestCommand_WhenGuestIsValid_ShouldCreateAndReturnGuest(
            CreateGuestCommand createGuestCommand)
        {
            var result = await _handler.Handle(createGuestCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createGuestCommand);
            _mockRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateGuestCommands()
        {
            yield return new[]
            {
                new CreateGuestCommand(
                    Constants.Guest.FirstName1,
                    Constants.Guest.LastName1,
                    Constants.Guest.ProfileImage1,
                    Constants.User.Id)
            };
        }
    }
}
