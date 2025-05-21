using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.MenuReviews.Commands.DeleteMenuReview;
using BuberDinner.Application.UnitTests.MenuReviews.TestUtils;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.MenuReviews.Commands.DeleteMenuReview
{
    public class DeleteMenuReviewCommandHandlerTests
    {
        private readonly DeleteMenuReviewCommandHandler _handler;
        private readonly Mock<IMenuReviewRepository> _mockRepository;
        private static readonly List<MenuReview> _menuReviews = new();

        public DeleteMenuReviewCommandHandlerTests()
        {
            _mockRepository = new Mock<IMenuReviewRepository>();
            _handler = new DeleteMenuReviewCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidDeleteMenuReviewCommands))]
        public async Task HandleDeleteMenuReviewCommand_WhenMenuReviewExists_ShouldDeleteAndReturnNoContent(
            DeleteMenuReviewCommand deleteMenuReviewCommand)
        {
            var menuReview = _menuReviews.First(m => m.Id == deleteMenuReviewCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(deleteMenuReviewCommand.Id))
                .ReturnsAsync(menuReview);

            var result = await _handler.Handle(deleteMenuReviewCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Deleted>();
            _mockRepository.Verify(m => m.GetAsync(deleteMenuReviewCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.DeleteAsync(menuReview), Times.Once);
        }

        public static IEnumerable<object[]> ValidDeleteMenuReviewCommands()
        {
            _menuReviews.AddRange(CreateMenuReviewUtils.CreateMenuReviewsList(3));

            foreach (var menuReview in _menuReviews)
            {
                yield return new[] { new DeleteMenuReviewCommand(menuReview.Id) };
            }
        }
    }
}
