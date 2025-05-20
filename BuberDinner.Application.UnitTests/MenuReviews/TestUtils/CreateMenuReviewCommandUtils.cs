using BuberDinner.Application.MenuReviews.Commands.CreateMenuReview;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Application.UnitTests.MenuReviews.TestUtils
{
    public static class CreateMenuReviewCommandUtils
    {
        public static CreateMenuReviewCommand CreateCommand(
            int index = 1) =>
            new CreateMenuReviewCommand(
                GetRating(index),
                GetComment(index),
                GetGuestId(index),
                GetDinnerId(index),
                GetHostId(index),
                GetMenuId(index));

        private static GuestId GetGuestId(int index) =>
            index switch
            {
                1 => Constants.Guest.Id1,
                2 => Constants.Guest.Id2,
                3 => Constants.Guest.Id3,
                _ => Constants.Guest.Id1
            };

        private static HostId GetHostId(int index) =>
            index switch
            {
                1 => Constants.Host.Id1,
                2 => Constants.Host.Id2,
                3 => Constants.Host.Id3,
                _ => Constants.Host.Id1
            };

        private static DinnerId GetDinnerId(int index) =>
            index switch
            {
                1 => Constants.Dinner.Id1,
                2 => Constants.Dinner.Id2,
                3 => Constants.Dinner.Id3,
                _ => Constants.Dinner.Id1
            };

        private static MenuId GetMenuId(int index) =>
            index switch
            {
                1 => Constants.Menu.Id1,
                2 => Constants.Menu.Id2,
                3 => Constants.Menu.Id3,
                _ => Constants.Menu.Id1
            };

        private static Rating GetRating(int index) =>
            index switch
            {
                1 => Rating.CreateNew(Constants.MenuReview.Rating1),
                2 => Rating.CreateNew(Constants.MenuReview.Rating2),
                3 => Rating.CreateNew(Constants.MenuReview.Rating3),
                _ => Rating.CreateNew(Constants.MenuReview.Rating1)
            };

        private static string GetComment(int index) =>
            index switch
            {
                1 => Constants.MenuReview.Comment1,
                2 => Constants.MenuReview.Comment2,
                3 => Constants.MenuReview.Comment3,
                _ => Constants.MenuReview.Comment1
            };
    }
}
