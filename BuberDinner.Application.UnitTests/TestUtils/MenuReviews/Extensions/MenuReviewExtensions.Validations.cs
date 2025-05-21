using BuberDinner.Application.MenuReviews.Commands.CreateMenuReview;
using BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview;
using BuberDinner.Domain.MenuReview;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.MenuReviews.Extensions
{
    public static partial class MenuReviewExtensions
    {
        public static void ValidateCreatedFrom(this MenuReview menuReview, CreateMenuReviewCommand command)
        {
            menuReview.Rating.Should().Be(command.Rating);
            menuReview.Comment.Should().Be(command.Comment);
            menuReview.HostId.Should().Be(command.HostId);
            menuReview.MenuId.Should().Be(command.MenuId);
            menuReview.GuestId.Should().Be(command.GuestId);
            menuReview.DinnerId.Should().Be(command.DinnerId);
        }

        public static void ValidateUpdatedFrom(this MenuReview menuReview, UpdateMenuReviewCommand command)
        {
            menuReview.Rating.Should().Be(command.Rating);
            menuReview.Comment.Should().Be(command.Comment);
        }
    }
}
