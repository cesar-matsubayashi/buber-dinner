using BuberDinner.Application.MenuReviews.Queries.GetMenuReview;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.MenuReviews.TestUtils;
using Moq;
using BuberDinner.Domain.MenuReview;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.MenuReviews.Queries.GetMenuReview
{
    public class GetMenuReviewQueryHandlerTests
    {

        private readonly GetMenuReviewQueryHandler _handler;
        private readonly Mock<IMenuReviewRepository> _mockRepository;
        private static readonly List<MenuReview> _menuReviews = new();

        public GetMenuReviewQueryHandlerTests()
        {
            _mockRepository = new Mock<IMenuReviewRepository>();
            _handler = new GetMenuReviewQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidGetMenuReviewQueries))]
        public async Task HandlerGetMenuReviewQuery_WhenMenuReviewExists_ShouldReturnMenuReview(
            GetMenuReviewQuery getMenuReviewQuery)
        {
            var menuReview = _menuReviews.First(m => m.Id == getMenuReviewQuery.Id);
            _mockRepository.Setup(r => r.GetAsync(getMenuReviewQuery.Id)).ReturnsAsync(menuReview);

            var result = await _handler.Handle(getMenuReviewQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(menuReview);
            _mockRepository.Verify(m => m.GetAsync(getMenuReviewQuery.Id), Times.Once);
        }

        public static IEnumerable<object[]> ValidGetMenuReviewQueries()
        {
            _menuReviews.AddRange(CreateMenuReviewUtils.CreateMenuReviewsList(3));

            foreach (var menuReview in _menuReviews)
            {
                yield return new[] { new GetMenuReviewQuery(menuReview.Id) };
            }
        }
    }
}
