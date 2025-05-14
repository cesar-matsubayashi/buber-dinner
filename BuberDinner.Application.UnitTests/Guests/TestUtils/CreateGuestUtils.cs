using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Application.UnitTests.Guests.TestUtils
{
    public class CreateGuestUtils
    {
        public static List<Guest> CreateGuests(
            int quantity = 1,
            bool guestRating = false)
        {
            List<Guest> guests = new();

            for (int i = 0; i < quantity; i++) { 
                var guest = Guest.Create(
                    GetFirstName(i),
                    GetLastName(i),
                    GetProfileImage(i),
                    GetUserId(i));

                if(guestRating)
                {
                    guest.AddGuestRating(
                        GetHostId(i),
                        GetDinnerId(i),
                        GetRating(i));
                }

                guests.Add(guest);
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

        private static Rating GetRating(int index) =>
            index switch
            {
                1 => Rating.CreateNew(Constants.GuestRating.Rating1),
                2 => Rating.CreateNew(Constants.GuestRating.Rating2),
                3 => Rating.CreateNew(Constants.GuestRating.Rating2),
                _ => Rating.CreateNew(0)
            };

        private static UserId GetUserId(int index) =>
            index switch
            {
                1 => Constants.User.Id1,
                2 => Constants.User.Id2,
                3 => Constants.User.Id3,
                _ => UserId.CreateUnique()
            };

        private static HostId GetHostId(int index) =>
            index switch
            {
                1 => Constants.Host.Id1,
                2 => Constants.Host.Id2,
                3 => Constants.Host.Id3,
                _ => HostId.CreateUnique()
            };

        private static DinnerId GetDinnerId(int index) =>
            index switch
            {
                1 => Constants.Dinner.Id1,
                2 => Constants.Dinner.Id2,
                3 => Constants.Dinner.Id3,
                _ => DinnerId.CreateUnique()
            };

    }
}
