using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Dinners.TestUtils
{
    public static class CreateDinnerCommandUtils
    {
        public static CreateDinnerCommand CreateCommand(
            DateTime? start = null,
            CreatePriceCommand? price = null)
        {
            DateTime startDateTime = start ?? Constants.Dinner.StartDateTime1;

            return new CreateDinnerCommand(
                Constants.Host.Id1,
                Constants.Dinner.Name1,
                Constants.Dinner.Description1,
                startDateTime,
                Constants.Dinner.EndDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.IsPublic1,
                Constants.Dinner.MaxGuests1,
                price ?? CreatePriceCommand(),
                Constants.Menu.Id1,
                Constants.Dinner.ImageUrl1,
                CreateLocationCommand());
        }

        public static CreatePriceCommand CreatePriceCommand(
            decimal price = Constants.Dinner.PriceAmount1)
        {
            return new CreatePriceCommand(
                price,
                Constants.Dinner.PriceCurrency1);
        }

        public static CreateLocationCommand CreateLocationCommand() =>
            new CreateLocationCommand(
                Constants.Dinner.LocationName1,
                Constants.Dinner.LocationAddress1,
                Constants.Dinner.LocationLatitude1,
                Constants.Dinner.LocationLongitude1);
    }
}
