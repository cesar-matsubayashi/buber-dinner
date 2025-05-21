using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByMenuId;
using BuberDinner.Application.UnitTests.MenuReviews.TestUtils;
using BuberDinner.Domain.MenuReview;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.MenuReviews.Queries.ListMenuReviewsByMenuId
{
    public class ListMenuReviewsByMenuIdHandlerTests
    {
        private readonly ListMenuReviewsByMenuIdQueryHandler _handler;
        private readonly Mock<IMenuReviewRepository> _mockRepository;
        private static readonly List<MenuReview> _menuReviews = new();

        public ListMenuReviewsByMenuIdHandlerTests()
        {
            _mockRepository = new Mock<IMenuReviewRepository>();
            _handler = new ListMenuReviewsByMenuIdQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidListMenuReviewsByMenuIdQueries))]
        public async Task HandleListMenuReviewsByMenuIdQuery_WhenMenuReviewExists_ShouldReturnMenuReviews(
            ListMenuReviewsByMenuIdQuery listMenuReviewsByMenuId)
        {
            var menuReviewsByMenuId = _menuReviews.Where(
                m => m.MenuId == listMenuReviewsByMenuId.MenuId)
                .ToList();
            _mockRepository.Setup(r => r.GetAllByMenuIdAsync(listMenuReviewsByMenuId.MenuId))
                .ReturnsAsync(menuReviewsByMenuId);

            var result = await _handler.Handle(listMenuReviewsByMenuId, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(menuReviewsByMenuId);
            _mockRepository.Verify(m => m.GetAllByMenuIdAsync(listMenuReviewsByMenuId.MenuId), Times.Once);
        }

        public static IEnumerable<object[]> ValidListMenuReviewsByMenuIdQueries()
        {
            _menuReviews.AddRange(CreateMenuReviewUtils.CreateMenuReviewsList(3));
            _menuReviews.Add(CreateMenuReviewUtils.CreateMenuReview(1));

            foreach (var menuReview in _menuReviews)
            {
                yield return new[] { new ListMenuReviewsByMenuIdQuery(menuReview.MenuId) };
            }
        }
    }
}
