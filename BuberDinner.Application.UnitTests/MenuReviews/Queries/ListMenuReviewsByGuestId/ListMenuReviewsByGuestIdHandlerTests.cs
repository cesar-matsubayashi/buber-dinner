using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByGuestId;
using BuberDinner.Application.UnitTests.MenuReviews.TestUtils;
using BuberDinner.Domain.MenuReview;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.MenuReviews.Queries.ListMenuReviewsByGuestId
{
    public class ListMenuReviewsByGuestIdHandlerTests
    {
        private readonly ListMenuReviewsByGuestIdQueryHandler _handler;
        private readonly Mock<IMenuReviewRepository> _mockRepository;
        private static readonly List<MenuReview> _menuReviews = new();

        public ListMenuReviewsByGuestIdHandlerTests()
        {
            _mockRepository = new Mock<IMenuReviewRepository>();
            _handler = new ListMenuReviewsByGuestIdQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidListMenuReviewsByGuestIdQueries))]
        public async Task HandlerListMenuReviewsByGuestIdQuery_WhenMenuReviewExists_ShouldReturnMenuReviews(
            ListMenuReviewsByGuestIdQuery listMenuReviewsByGuestId)
        {
            _mockRepository.Setup(r => r.GetAllByGuestIdAsync(listMenuReviewsByGuestId.GuestId))
                .ReturnsAsync(_menuReviews);

            var result = await _handler.Handle(listMenuReviewsByGuestId, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(_menuReviews);
            _mockRepository.Verify(m => m.GetAllByGuestIdAsync(listMenuReviewsByGuestId.GuestId), Times.Once);
        }

        public static IEnumerable<object[]> ValidListMenuReviewsByGuestIdQueries()
        {
            _menuReviews.AddRange(CreateMenuReviewUtils.CreateMenuReviewsList(3));
            _menuReviews.Add(CreateMenuReviewUtils.CreateMenuReview(1));

            foreach (var menuReview in _menuReviews)
            {
                yield return new[] { new ListMenuReviewsByGuestIdQuery(menuReview.GuestId) };
            }
        }
    }
}
