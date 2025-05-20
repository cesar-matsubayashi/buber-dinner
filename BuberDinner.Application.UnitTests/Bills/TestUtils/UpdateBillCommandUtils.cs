using BuberDinner.Application.Bills.Commands.UpdateBill;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Bill.ValueObjects;

namespace BuberDinner.Application.UnitTests.Bills.TestUtils
{
    public static class UpdateBillCommandUtils
    {
        public static UpdateBillCommand CreateCommand(
            BillId id,
            UpdatePriceCommand? price = null) =>
            new UpdateBillCommand(
                id,
                price ?? CreatePriceCommand());

        public static UpdatePriceCommand CreatePriceCommand(
            decimal amount = Constants.Bill.PriceAmount1,
            string currency = Constants.Bill.PriceCurrency1) =>
            new UpdatePriceCommand(
                amount,
                currency);
    }
}
