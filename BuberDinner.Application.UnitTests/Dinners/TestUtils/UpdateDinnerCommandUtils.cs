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
            DateTime startDateTime = start ?? Constants.Dinner.StartDateTime.Update();

            return new UpdateDinnerCommand(
                id,
                Constants.Dinner.Name.Update(),
                Constants.Dinner.Description.Update(),
                startDateTime,
                Constants.Dinner.EndDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.StartedDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.EndedDateTimeFromStartDateTime(startDateTime),
                DinnerStatus.Ended,
                Constants.Dinner.IsPublic,
                Constants.Dinner.MaxGuests.Update(),
                price ?? UpdatePriceCommand(),
                Constants.Menu.Id,
                Constants.Dinner.ImageUrl.Update(),
                UpdateLocationCommand());
        }

        public static UpdatePriceCommand UpdatePriceCommand(
            decimal price = Constants.Dinner.PriceAmount)
        {
            return new UpdatePriceCommand(
                price,
                Constants.Dinner.PriceCurrency);
        }

        public static UpdateLocationCommand UpdateLocationCommand() =>
            new UpdateLocationCommand(
                Constants.Dinner.LocationName.Update(),
                Constants.Dinner.LocationAddress.Update(),
                Constants.Dinner.LocationLatitude.Update(),
                Constants.Dinner.LocationLongitude.Update());
    }
}
