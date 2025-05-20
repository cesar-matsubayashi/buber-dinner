using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Application.UnitTests.Bills.TestUtils
{
    public  class CreateBillUtils
    {
        public static List<Bill> CreateBills(
            int quantity = 1)
        {
            List<Bill> bills = new();

            for (int i = 0; i < quantity; i++)
            {
                var bill = Bill.Create(
                    GetDinnerId(i),
                    GetGuestId(i),
                    GetHostId(i),
                    GetPrice(i));

                bills.Add(bill);
            }

            return bills;
        }

        public static Bill CreateBill(int index)
        {
            return Bill.Create(
                GetDinnerId(index),
                GetGuestId(index),
                GetHostId(index),
                GetPrice(index));
        }

        private static DinnerId GetDinnerId(int index) =>
            index switch
            {
                1 => Constants.Dinner.Id1,
                2 => Constants.Dinner.Id2,
                3 => Constants.Dinner.Id3,
                _ => Constants.Dinner.Id1
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

        private static Price GetPrice(int index) =>
           index switch
           {
               1 => Price.Create(
                    Constants.Bill.PriceAmount1,
                    Constants.Bill.PriceCurrency1),
               2 => Price.Create(
                    Constants.Bill.PriceAmount2,
                    Constants.Bill.PriceCurrency2),
               3 => Price.Create(
                    Constants.Bill.PriceAmount3,
                    Constants.Bill.PriceCurrency3),
               _ => Price.Create(
                    Constants.Bill.PriceAmount1,
                    Constants.Bill.PriceCurrency1)
           };
    }
}
