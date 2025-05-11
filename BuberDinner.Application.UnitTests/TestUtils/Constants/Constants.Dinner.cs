using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Dinner
        {
            public static readonly DinnerId Id = DinnerId.Create(
                Guid.Parse("65f38155-7984-48dc-96f5-1ecca8ca427d"));

            public const string Name = "Dinner Name";
            public const string Description = "Dinner Description";
            public const DinnerStatus Status = DinnerStatus.Upcoming;
            public const bool IsPublic = true;
            public const int MaxGuests = 10;
            public const string ImageUrl = "https://image.com";

            public const decimal PriceAmount = 10.99m;
            public const string PriceCurrency = "USD";

            public const string LocationName = "Dan's Pizza Place";
            public const string LocationAddress = "Berlin, Germany";
            public const float LocationLatitude = 52.520008f;
            public const float LocationLongitude = 13.404954f;

            public static readonly DateTime StartDateTime =
                new DateTime(2025, 5, 9, 19, 0, 0, DateTimeKind.Utc);

            public static DateTime EndDateTimeFromStartDateTime(DateTime startDateTime) =>
                startDateTime.AddHours(2);

            public static DateTime StartedDateTimeFromStartDateTime(DateTime startDateTime) =>
                startDateTime.AddMinutes(5);

            public static DateTime EndedDateTimeFromStartDateTime(DateTime startDateTime) =>
                startDateTime.AddHours(1).AddMinutes(51);
        }

        public static class Reservation
        {
            public static readonly ReservationId Id = ReservationId.Create(
                Guid.Parse("b875aa89-7ad6-4456-bb34-ea53c2d721a9"));

            public const int GuestCount = 2;

            public static DateTime ArrivalDateTimeFromStartDateTime(DateTime startDateTime) =>
                startDateTime.AddMinutes(1);
        }
    }
}
