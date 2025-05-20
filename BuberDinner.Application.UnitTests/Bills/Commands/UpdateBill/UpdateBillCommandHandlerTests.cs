using BuberDinner.Application.Bills.Commands.UpdateBill;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.Bills.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Bills.Extensions;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Bill;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Bills.Commands.UpdateBill
{
    public class UpdateBillCommandHandlerTests
    {
        private readonly UpdateBillCommandHandler _handler;
        private readonly Mock<IBillRepository> _mockRepository;
        private static readonly List<Bill> _bills = new();

        public UpdateBillCommandHandlerTests()
        {
            _mockRepository = new Mock<IBillRepository>();
            _handler = new UpdateBillCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateBillCommands))]
        public async Task HandleUpdateBillCommand_WhenBillExists_ShoulUpdateBillAndReturnNoContent(
            UpdateBillCommand updateBillCommand)
        {
            var bill = _bills.First(m => m.Id == updateBillCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(updateBillCommand.Id))
                .ReturnsAsync(bill);

            var result = await _handler.Handle(updateBillCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateBillCommand);
            _mockRepository.Verify(m => m.GetAsync(updateBillCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(bill), Times.Once);
        }

        public static IEnumerable<object[]> ValidUpdateBillCommands()
        {
            _bills.AddRange(CreateBillUtils.CreateBills(3));
            
            yield return new[] 
            {
                UpdateBillCommandUtils.CreateCommand(_bills[0].Id)
            };

            yield return new[]
            {
                UpdateBillCommandUtils.CreateCommand(
                    _bills[0].Id,
                    price: UpdateBillCommandUtils.CreatePriceCommand(
                        amount: Constants.Bill.PriceAmount3,
                        currency: Constants.Bill.PriceCurrency3))
            };
        }
    }
}
