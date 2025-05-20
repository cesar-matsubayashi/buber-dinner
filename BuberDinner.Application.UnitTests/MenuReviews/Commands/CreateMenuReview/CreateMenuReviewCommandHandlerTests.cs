using BuberDinner.Application.MenuReviews.Commands.CreateMenuReview;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.MenuReviews.TestUtils;
using Moq;
using FluentAssertions;
using BuberDinner.Application.UnitTests.TestUtils.MenuReviews.Extensions;

namespace BuberDinner.Application.UnitTests.MenuReviews.Commands.CreateMenuReview
{
    public class CreateMenuReviewCommandHandlerTests
    {
        private readonly CreateMenuReviewCommandHandler _handler;
        private readonly Mock<IMenuReviewRepository> _mockRepository;

        public CreateMenuReviewCommandHandlerTests()
        {
            _mockRepository = new Mock<IMenuReviewRepository>();
            _handler = new CreateMenuReviewCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateMenuReviewCommands))]
        public async Task HandleCreateMenuReviewCommand_WhenMenuReviewIsValid_ShouldCreateAndReturnMenuReview(
            CreateMenuReviewCommand createMenuReviewCommand)
        {
            var result = await _handler.Handle(createMenuReviewCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createMenuReviewCommand);
            _mockRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateMenuReviewCommands()
        {
            yield return new[] { CreateMenuReviewCommandUtils.CreateCommand() };
        }
    }
}
