using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;

namespace BuberDinner.Application.UnitTests.MenuReviews.TestUtils
{
    public class CreateMenuReviewUtils
    {
        public static List<MenuReview> CreateMenuReviewsList(
            int quantity = 1)
        {
            List<MenuReview> menuReviews = new();

            for (int i = 0; i < quantity; i++)
            {
                var menuReview = MenuReview.Create(
                    GetRating(i),
                    GetComment(i),
                    GetHostId(i),
                    GetMenuId(i),
                    GetGuestId(i),
                    GetDinnerId(i));

                menuReviews.Add(menuReview);
            }

            return menuReviews;
        }
        public static MenuReview CreateMenuReview(int index = 1) =>
            MenuReview.Create(
                GetRating(index),
                GetComment(index),
                GetHostId(index),
                GetMenuId(index),
                GetGuestId(index),
                GetDinnerId(index));

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
