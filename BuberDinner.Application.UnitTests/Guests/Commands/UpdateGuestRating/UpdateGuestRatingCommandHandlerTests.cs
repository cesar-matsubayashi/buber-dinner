using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Guests.Commands.UpdateGuestRating;
using BuberDinner.Application.UnitTests.Guests.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Guests.Extensions;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Guests.Commands.UpdateGuestRating
{
    public class UpdateGuestRatingCommandHandlerTests
    {
        private readonly UpdateGuestRatingCommandHandler _handler;
        private readonly Mock<IGuestRepository> _mockRepository;
        private static readonly List<Guest> _guests = new();

        public UpdateGuestRatingCommandHandlerTests()
        {
            _mockRepository = new Mock<IGuestRepository>();
            _handler = new UpdateGuestRatingCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateGuestRatingCommands))]
        public async Task HandleUpdateGuestRatingCommand_WhenGuestRatingIsValid_ShouldUpdateAndReturnGuestRating(
            UpdateGuestRatingCommand updateGuestRatingCommand)
        {
            var guest = _guests.First(h => h.Id == updateGuestRatingCommand.GuestId);
            _mockRepository.Setup(r => r.GetAsync(updateGuestRatingCommand.GuestId))
                .ReturnsAsync(guest);

            var result = await _handler.Handle(updateGuestRatingCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateGuestRatingCommand);
            guest.GuestRatings.Should().ContainEquivalentOf(result.Value);
            _mockRepository.Verify(m => m.GetAsync(updateGuestRatingCommand.GuestId), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(guest), Times.Once);
        }

        public static IEnumerable<object[]> ValidUpdateGuestRatingCommands()
        {
            _guests.AddRange(CreateGuestUtils.CreateGuests(
                quantity: 3,
                guestRating: true));

            yield return new[]
            {
                new UpdateGuestRatingCommand(
                    _guests[0].GuestRatings.First().Id,
                    _guests[0].Id,
                    Rating.CreateNew(Constants.GuestRating.Rating2))
            };
        }
    }
}
