using BuberDinner.Application.Bills.Commands.CreateBill;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.Bills.TestUtils
{
    public static class CreateBillCommandUtils
    {
        public static CreateBillCommand CreateCommand(
            int index = 1) =>
            new CreateBillCommand(
                GetGuestId(index),
                GetDinnerId(index),
                GetHostId(index),
                GetCreatePriceCommand(index));

        private static CreatePriceCommand GetCreatePriceCommand(int index) =>
           index switch
           {
               1 => new CreatePriceCommand(
                    Constants.Bill.PriceAmount1,
                    Constants.Bill.PriceCurrency1),
               2 => new CreatePriceCommand(
                    Constants.Bill.PriceAmount2,
                    Constants.Bill.PriceCurrency2),
               3 => new CreatePriceCommand(
                    Constants.Bill.PriceAmount3,
                    Constants.Bill.PriceCurrency3),
               _ => new CreatePriceCommand(
                    Constants.Bill.PriceAmount1,
                    Constants.Bill.PriceCurrency1)
           };

        private static GuestId GetGuestId(int index) =>
            index switch
            {
                1 => Constants.Guest.Id1,
                2 => Constants.Guest.Id2,
                3 => Constants.Guest.Id3,
                _ => Constants.Guest.Id1
            };

        private static HostId GetHostId(int index) =>
            index switch
            {
                1 => Constants.Host.Id1,
                2 => Constants.Host.Id2,
                3 => Constants.Host.Id3,
                _ => Constants.Host.Id1
            };

        private static DinnerId GetDinnerId(int index) =>
            index switch
            {
                1 => Constants.Dinner.Id1,
                2 => Constants.Dinner.Id2,
                3 => Constants.Dinner.Id3,
                _ => Constants.Dinner.Id1
            };
    }
}
