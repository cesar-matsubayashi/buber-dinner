using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Guests.Commands.DeleteGuest;
using BuberDinner.Application.Guests.Commands.DeleteGuest;
using BuberDinner.Application.Hosts.Commands.DeleteHost;
using BuberDinner.Application.UnitTests.Guests.TestUtils;
using BuberDinner.Domain.Guest;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Guests.Commands.DeleteGuest
{
    public class DeleteGuestCommandHandlerTests
    {
        private readonly DeleteGuestCommandHandler _handler;
        private readonly Mock<IGuestRepository> _mockRepository;
        private static readonly List<Guest> _guests = new();

        public DeleteGuestCommandHandlerTests()
        {
            _mockRepository = new Mock<IGuestRepository>();
            _handler = new DeleteGuestCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidDeleteGuestCommands))]
        public async Task HandleDeleteGuestCommand_WhenGuestExists_ShouldDeleteGuestAndReturnNoContent(
            DeleteGuestCommand deleteGuestCommand)
        {
            var guest = _guests.First(h => h.Id == deleteGuestCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(deleteGuestCommand.Id))
                .ReturnsAsync(guest);

            var result = await _handler.Handle(deleteGuestCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Deleted>();
            _mockRepository.Verify(m => m.GetAsync(deleteGuestCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.DeleteAsync(guest), Times.Once);
        }

        public static IEnumerable<object[]> ValidDeleteGuestCommands()
        {
            _guests.AddRange(CreateGuestUtils.CreateGuests(3));

            foreach (var guest in _guests)
            {
                yield return new[] { new DeleteGuestCommand(guest.Id) };
            }
        }
    }
}
