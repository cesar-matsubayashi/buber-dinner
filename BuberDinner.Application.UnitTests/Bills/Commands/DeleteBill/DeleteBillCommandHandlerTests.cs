using BuberDinner.Application.Bills.Commands.DeleteBill;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.Bills.TestUtils;
using BuberDinner.Domain.Bill;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Bills.Commands.DeleteBill
{
    public class DeleteBillCommandHandlerTests
    {
        private readonly DeleteBillCommandHandler _handler;
        private readonly Mock<IBillRepository> _mockRepository;
        private static readonly List<Bill> _bills = new();

        public DeleteBillCommandHandlerTests()
        {
            _mockRepository = new Mock<IBillRepository>();
            _handler = new DeleteBillCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidDeleteBillCommands))]
        public async Task HandleDeleteBillCommand_WhenBillExists_ShoulDeleteBillAndReturnNoContent(
            DeleteBillCommand deleteBillCommand)
        {
            var bill = _bills.First(m => m.Id == deleteBillCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(deleteBillCommand.Id))
                .ReturnsAsync(bill);

            var result = await _handler.Handle(deleteBillCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Deleted>();
            _mockRepository.Verify(m => m.GetAsync(deleteBillCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.DeleteAsync(bill), Times.Once);
        }

        public static IEnumerable<object[]> ValidDeleteBillCommands()
        {
            _bills.AddRange(CreateBillUtils.CreateBills(3));

            foreach (var bill in _bills)
            {
                yield return new[] { new DeleteBillCommand(bill.Id) };
            }
        }
    }
}
