using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Guests.Queries.GetGuest;
using BuberDinner.Application.UnitTests.Guests.TestUtils;
using BuberDinner.Domain.Guest;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Guests.Queries.GetGuest
{
    public class GetGuestQueryHandlerTests
    {
        private readonly GetGuestQueryHandler _handler;
        private readonly Mock<IGuestRepository> _mockRepository;
        private static readonly List<Guest> _guests = new();

        public GetGuestQueryHandlerTests()
        {
            _mockRepository = new Mock<IGuestRepository>();
            _handler = new GetGuestQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidGetGuestQueries))]
        public async Task HandlerGetGuestCommand_WhenGuestExists_ShouldReturnGuest(
            GetGuestQuery getGuestQuery)
        {
            var guest = _guests.First(g => g.Id == getGuestQuery.Id);
            _mockRepository.Setup(r => r.GetAsync(getGuestQuery.Id))
                .ReturnsAsync(guest);

            var result = await _handler.Handle(getGuestQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(guest);
            _mockRepository.Verify(g => g.GetAsync(getGuestQuery.Id), Times.Once);
        }

        public static IEnumerable<object[]> ValidGetGuestQueries()
        {
            _guests.AddRange(CreateGuestUtils.CreateGuests(3));

            foreach (var guest in _guests)
            {
                yield return new[] { new GetGuestQuery(guest.Id) };
            }
        }
    }
}
