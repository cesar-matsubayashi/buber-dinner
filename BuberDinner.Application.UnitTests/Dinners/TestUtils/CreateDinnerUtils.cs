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
            Price? price = null,
            bool reservation = false)
        {
            DateTime startDateTime = start ?? Constants.Dinner.StartDateTime1;
            
            var dinner = Dinner.Create(
                Constants.Host.Id1,
                Constants.Dinner.Name1,
                Constants.Dinner.Description1,
                startDateTime,
                Constants.Dinner.EndDateTimeFromStartDateTime(startDateTime),
                Constants.Dinner.IsPublic1,
                Constants.Dinner.MaxGuests1,
                price ?? CreatePrice(),
                Constants.Menu.Id1,
                Constants.Dinner.ImageUrl1,
                CreateLocation());

            if (reservation)
            {
                dinner.AddReservation(
                    Constants.Reservation.GuestCount,
                    Constants.Guest.Id1,
                    Constants.Bill.Id1);

                dinner.AddReservation(
                    Constants.Reservation.GuestCount,
                    Constants.Guest.Id2,
                    Constants.Bill.Id2);
            }

            return dinner;
        }

        public static Price CreatePrice(
            decimal price = Constants.Dinner.PriceAmount1)
        {
            return Price.Create(
                price,
                Constants.Dinner.PriceCurrency1);
        }

        public static Location CreateLocation() =>
            Location.Create(
                Constants.Dinner.LocationName1,
                Constants.Dinner.LocationAddress1,
                Constants.Dinner.LocationLatitude1,
                Constants.Dinner.LocationLongitude1);
    }
}
