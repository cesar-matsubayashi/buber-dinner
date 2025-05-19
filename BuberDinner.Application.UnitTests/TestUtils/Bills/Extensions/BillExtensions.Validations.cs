using BuberDinner.Application.Bills.Commands.CreateBill;
using BuberDinner.Domain.Bill;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Bills.Extensions
{
    public static partial class BillExtensions
    {
        public static void ValidateCreatedFrom(this Bill bill, CreateBillCommand command)
        {
            bill.GuestId.Should().Be(command.GuestId);
            bill.DinnerId.Should().Be(command.DinnerId);
            bill.HostId.Should().Be(command.HostId);
            bill.Price.Amount.Should().Be(command.Price.Amount);
            bill.Price.Currency.Should().Be(command.Price.Currency);
        }
    }
}
