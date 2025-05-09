using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Application.UnitTests.Dinners.TestUtils
{
    public static class CreateDinnerCommandUtils
    {
        public static CreateDinnerCommand CreateCommand(
            DateTime? start = null,
            CreatePriceCommand? price = null)
        {
            DateTime startDateTime = start ?? Constants.Dinner.StartDateTime;

            return new CreateDinnerCommand(
                Constants.Host.Id,
                Constants.Dinner.Name,
                Constants.Dinner.Description,
                startDateTime,
                Constants.Dinner.EndDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.IsPublic,
                Constants.Dinner.MaxGuests,
                price ?? CreatePriceCommand(),
                Constants.Menu.Id,
                Constants.Dinner.ImageUrl,
                CreateLocationCommand());
        }

        public static CreatePriceCommand CreatePriceCommand(
            decimal price = Constants.Dinner.PriceAmount)
        {
            return new CreatePriceCommand(
                price,
                Constants.Dinner.PriceCurrency);
        }

        public static CreateLocationCommand CreateLocationCommand() =>
            new CreateLocationCommand(
                Constants.Dinner.LocationName,
                Constants.Dinner.LocationAddress,
                Constants.Dinner.LocationLatitude,
                Constants.Dinner.LocationLongitude);
    }
}
