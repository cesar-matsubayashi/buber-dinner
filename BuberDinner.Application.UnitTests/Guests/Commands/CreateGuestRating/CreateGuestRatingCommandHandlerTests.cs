using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Guests.Commands.CreateGuestRating;
using BuberDinner.Application.Guests.Commands.UpdateGuest;
using BuberDinner.Application.UnitTests.Guests.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.Guests.Extensions;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Guests.Commands.CreateGuestRating
{
    public class CreateGuestRatingCommandHandlerTests
    {
        private readonly CreateGuestRatingCommandHandler _handler;
        private readonly Mock<IGuestRepository> _mockRepository;
        private static readonly List<Guest> _guests = new();

        public CreateGuestRatingCommandHandlerTests()
        {
            _mockRepository = new Mock<IGuestRepository>();
            _handler = new CreateGuestRatingCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateGuestRatingCommands))]
        public async Task HandleCreateGuestRatingCommand_WhenGuestRatingIsValid_ShouldCreateAndReturnGuestRating(
            CreateGuestRatingCommand createGuestRatingCommand)
        {
            var guest = _guests.First(h => h.Id == createGuestRatingCommand.GuestId);
            _mockRepository.Setup(r => r.GetAsync(createGuestRatingCommand.GuestId))
                .ReturnsAsync(guest);

            var result = await _handler.Handle(createGuestRatingCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createGuestRatingCommand);
            guest.GuestRatings.Should().ContainEquivalentOf(result.Value);
            _mockRepository.Verify(m => m.GetAsync(createGuestRatingCommand.GuestId), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(guest), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateGuestRatingCommands()
        {
            _guests.AddRange(CreateGuestUtils.CreateGuests(3));

            yield return new[]
            {
                new CreateGuestRatingCommand(
                    _guests[0].Id,
                    Constants.Host.Id1,
                    Constants.Dinner.Id1,
                    Rating.CreateNew(Constants.GuestRating.Rating1))
            };

            yield return new[]
            {
                new CreateGuestRatingCommand(
                    _guests[0].Id,
                    Constants.Host.Id2,
                    Constants.Dinner.Id2,
                    Rating.CreateNew(Constants.GuestRating.Rating2))
            };
        }
    }
}
