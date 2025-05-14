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
            public static readonly DinnerId Id1 = DinnerId.Create(
                Guid.Parse("65f38155-7984-48dc-96f5-1ecca8ca427d"));
            public const string Name1 = "Dinner Name";
            public const string Description1 = "Dinner Description";
            //public const DinnerStatus Status = DinnerStatus.Upcoming;
            public const bool IsPublic1 = true;
            public const int MaxGuests1 = 10;
            public const string ImageUrl1 = "https://image.com";
            public const decimal PriceAmount1 = 10.99m;
            public const string PriceCurrency1 = "USD";
            public const string LocationName1 = "Dan's Pizza Place";
            public const string LocationAddress1 = "Berlin, Germany";
            public const float LocationLatitude1 = 52.520008f;
            public const float LocationLongitude1 = 13.404954f;
            public static readonly DateTime StartDateTime1 =
                new DateTime(2025, 5, 9, 19, 0, 0, DateTimeKind.Utc);

            public static readonly DinnerId Id2 = DinnerId.Create(
                Guid.Parse("7133c539-bedc-4381-91a8-fe4e5df8be59"));
            public const string Name2 = "Dinner Name";
            public const string Description2 = "Dinner Description";
            //public const DinnerStatus Status = DinnerStatus.Upcoming;
            public const bool IsPublic2 = true;
            public const int MaxGuests2 = 20;
            public const string ImageUrl2 = "https://image.com";
            public const decimal PriceAmount2 = 20.99m;
            public const string PriceCurrency2 = "USD";
            public const string LocationName2 = "Dan's Pizza Place";
            public const string LocationAddress2 = "Berlin, Germany";
            public const float LocationLatitude2 = 52.520008f;
            public const float LocationLongitude2 = 23.404954f;
            public static readonly DateTime StartDateTime2 =
                new DateTime(2025, 5, 9, 19, 0, 0, DateTimeKind.Utc);

            public static readonly DinnerId Id3 = DinnerId.Create(
                Guid.Parse("4df027fb-b42a-4448-92b1-111cdc4c88cd"));
            public const string Name3 = "Dinner Name";
            public const string Description3 = "Dinner Description";
            //public const DinnerStatus Status = DinnerStatus.Upcoming;
            public const bool IsPublic3 = true;
            public const int MaxGuests3 = 30;
            public const string ImageUrl3 = "https://image.com";
            public const decimal PriceAmount3 = 30.99m;
            public const string PriceCurrency3 = "USD";
            public const string LocationName3 = "Dan's Pizza Place";
            public const string LocationAddress3 = "Berlin, Germany";
            public const float LocationLatitude3 = 52.520008f;
            public const float LocationLongitude3 = 33.404954f;
            public static readonly DateTime StartDateTime3 =
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
