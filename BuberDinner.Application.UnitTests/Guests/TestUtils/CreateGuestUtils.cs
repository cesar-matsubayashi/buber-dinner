using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Application.UnitTests.Guests.TestUtils
{
    public class CreateGuestUtils
    {
        public static List<Guest> CreateGuests(int quantity = 1)
        {
            List<Guest> guests = new();

            for (int i = 0; i < quantity; i++) { 
                guests.Add(Guest.Create(
                    GetFirstName(i),
                    GetLastName(i),
                    GetProfileImage(i),
                    GetUserId(i)));
            }

            return guests;
        }

        private static string GetFirstName(int index) =>
            index switch
            {
                1 => Constants.Guest.FirstName1,
                2 => Constants.Guest.FirstName2,
                3 => Constants.Guest.FirstName3,
                _ => $"FirstName{index}"
            };

        private static string GetLastName(int index) =>
            index switch
            {
                1 => Constants.Guest.LastName1,
                2 => Constants.Guest.LastName2,
                3 => Constants.Guest.LastName3,
                _ => $"LastName{index}"
            };

        private static string GetProfileImage(int index) =>
            index switch
            {
                1 => Constants.Guest.ProfileImage1,
                2 => Constants.Guest.ProfileImage2,
                3 => Constants.Guest.ProfileImage3,
                _ => $"ProfileImage{index}"
            };

        private static UserId GetUserId(int index) =>
            index switch
            {
                1 => Constants.User.Id1,
                2 => Constants.User.Id2,
                3 => Constants.User.Id3,
                _ => UserId.CreateUnique()
            };

    }
}
