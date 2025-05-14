using BuberDinner.Application.Guests.Commands.CreateGuestRating;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Application.UnitTests.Guests.TestUtils
{
    public  class CreateGuestRatingCommandUtils
    {
        public static CreateGuestRatingCommand CreateGuestRating1(GuestId guestId) =>
            new CreateGuestRatingCommand(
                guestId,
                Constants.Host.Id1,
                Constants.Dinner.Id1,
                Rating.CreateNew(Constants.GuestRating.Rating1));

        public static CreateGuestRatingCommand CreateGuestRating2(GuestId guestId) =>
            new CreateGuestRatingCommand(
                guestId,
                Constants.Host.Id2,
                Constants.Dinner.Id2,
                Rating.CreateNew(Constants.GuestRating.Rating2));

        public static CreateGuestRatingCommand CreateGuestRating3(GuestId guestId) =>
            new CreateGuestRatingCommand(
                guestId,
                Constants.Host.Id3,
                Constants.Dinner.Id3,
                Rating.CreateNew(Constants.GuestRating.Rating2));
    }
}
