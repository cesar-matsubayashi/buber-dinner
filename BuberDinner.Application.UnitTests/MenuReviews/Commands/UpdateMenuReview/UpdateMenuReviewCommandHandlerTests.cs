using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview;
using BuberDinner.Application.UnitTests.MenuReviews.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.MenuReviews.Extensions;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.MenuReviews.Commands.UpdateMenuReview
{
    public class UpdateMenuReviewCommandHandlerTests
    {
        private readonly UpdateMenuReviewCommandHandler _handler;
        private readonly Mock<IMenuReviewRepository> _mockRepository;
        private static readonly List<MenuReview> _menuReviews = new();

        public UpdateMenuReviewCommandHandlerTests()
        {
            _mockRepository = new Mock<IMenuReviewRepository>();
            _handler = new UpdateMenuReviewCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateMenuReviewCommands))]
        public async Task HandleUpdateMenuReviewCommand_WhenMenuReviewIsValid_ShouldUpdateAndReturnMenuReview(
            UpdateMenuReviewCommand updateMenuReviewCommand)
        {
            var menuReview = _menuReviews.First(m => m.Id == updateMenuReviewCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(updateMenuReviewCommand.Id))
                .ReturnsAsync(menuReview);

            var result = await _handler.Handle(updateMenuReviewCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateMenuReviewCommand);
            _mockRepository.Verify(m => m.GetAsync(updateMenuReviewCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(menuReview), Times.Once);
        }

        public static IEnumerable<object[]> ValidUpdateMenuReviewCommands()
        {
            _menuReviews.AddRange(CreateMenuReviewUtils.CreateMenuReviewsList(3));

            yield return new[] 
            { 
                new UpdateMenuReviewCommand(
                    _menuReviews[0].Id,
                    Rating.CreateNew(Constants.MenuReview.Rating3),
                    Constants.MenuReview.Comment1) 
            };

            yield return new[]
            {
                new UpdateMenuReviewCommand(
                    _menuReviews[1].Id,
                    Rating.CreateNew(Constants.MenuReview.Rating1),
                    Constants.MenuReview.Comment1)
            };
        }
    }
}
