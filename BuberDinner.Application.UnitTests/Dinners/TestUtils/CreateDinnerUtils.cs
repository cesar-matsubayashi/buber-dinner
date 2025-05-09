using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.Entities;

namespace BuberDinner.Application.UnitTests.Dinners.TestUtils
{
    public static class CreateDinnerUtils
    {
        public static Dinner CreateDinner(
            DateTime? start = null,
            Price? price = null)
        {
            DateTime startDateTime = start ?? Constants.Dinner.StartDateTime;

            return Dinner.Create(
                Constants.Host.Id,
                Constants.Dinner.Name,
                Constants.Dinner.Description,
                startDateTime,
                Constants.Dinner.EndDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.IsPublic,
                Constants.Dinner.MaxGuests,
                price ?? CreatePrice(),
                Constants.Menu.Id,
                Constants.Dinner.ImageUrl,
                CreateLocation());
        }

        public static Price CreatePrice(
            decimal price = Constants.Dinner.PriceAmount)
        {
            return Price.Create(
                price,
                Constants.Dinner.PriceCurrency);
        }

        public static Location CreateLocation() =>
            Location.Create(
                Constants.Dinner.LocationName,
                Constants.Dinner.LocationAddress,
                Constants.Dinner.LocationLatitude,
                Constants.Dinner.LocationLongitude);
    }
}
