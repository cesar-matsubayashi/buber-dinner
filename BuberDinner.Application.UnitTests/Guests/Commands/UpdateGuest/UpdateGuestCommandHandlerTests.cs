using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Guests.Commands.UpdateGuest;
using BuberDinner.Application.UnitTests.Guests.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Guests.Extensions;
using BuberDinner.Application.UnitTests.TestUtils.Common.Extensions;
using BuberDinner.Domain.Guest;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandHandlerTests
    {
        private readonly UpdateGuestCommandHandler _handler;
        private readonly Mock<IGuestRepository> _mockRepository;
        private static readonly List<Guest> _guests = new();

        public UpdateGuestCommandHandlerTests()
        {
            _mockRepository = new Mock<IGuestRepository>();
            _handler = new UpdateGuestCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateGuestCommands))]
        public async Task HandleUpdateGuestCommand_WhenUpdateIsValid_ShouldUpdateAndReturnGuest(
            UpdateGuestCommand updateGuestCommand)
        {
            var guest = _guests.First(h => h.Id == updateGuestCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(updateGuestCommand.Id))
            .ReturnsAsync(guest);

            var result = await _handler.Handle(updateGuestCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateGuestCommand);
            _mockRepository.Verify(m => m.GetAsync(result.Value.Id), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidUpdateGuestCommands()
        {
            _guests.AddRange(CreateGuestUtils.CreateGuests(3));

            yield return new[]
            {
                new UpdateGuestCommand(
                    _guests[0].Id,
                    _guests[0].FirstName.Update(),
                    _guests[0].LastName.Update(),
                    _guests[0].ProfileImage.Update())
            };
        }
    }
}
