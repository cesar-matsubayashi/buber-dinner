using BuberDinner.Application.Dinners.Commands.UpdateDinner;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Application.UnitTests.TestUtils.Common.Extensions;

namespace BuberDinner.Application.UnitTests.Dinners.TestUtils
{
    public class UpdateDinnerCommandUtils
    {
        public static UpdateDinnerCommand UpdateCommand(
            DinnerId id,
            DateTime? start = null,
            UpdatePriceCommand? price = null)
        {
            DateTime startDateTime = start ?? Constants.Dinner.StartDateTime1.Update();

            return new UpdateDinnerCommand(
                id,
                Constants.Dinner.Name1.Update(),
                Constants.Dinner.Description1.Update(),
                startDateTime,
                Constants.Dinner.EndDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.StartedDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.EndedDateTimeFromStartDateTime(startDateTime),
                DinnerStatus.Ended,
                Constants.Dinner.IsPublic1,
                Constants.Dinner.MaxGuests1.Update(),
                price ?? UpdatePriceCommand(),
                Constants.Menu.Id1,
                Constants.Dinner.ImageUrl1.Update(),
                UpdateLocationCommand());
        }

        public static UpdatePriceCommand UpdatePriceCommand(
            decimal price = Constants.Dinner.PriceAmount1)
        {
            return new UpdatePriceCommand(
                price,
                Constants.Dinner.PriceCurrency1);
        }

        public static UpdateLocationCommand UpdateLocationCommand() =>
            new UpdateLocationCommand(
                Constants.Dinner.LocationName1.Update(),
                Constants.Dinner.LocationAddress1.Update(),
                Constants.Dinner.LocationLatitude1.Update(),
                Constants.Dinner.LocationLongitude1.Update());
    }
}
