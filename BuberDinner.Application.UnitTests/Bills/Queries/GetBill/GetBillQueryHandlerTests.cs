using BuberDinner.Application.Bills.Queries.GetBill;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.Bills.TestUtils;
using BuberDinner.Domain.Bill;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Bills.Queries.GetBill
{
    public class GetBillQueryHandlerTests
    {
        private readonly GetBillQueryHandler _handler;
        private readonly Mock<IBillRepository> _mockRepository;
        private static readonly List<Bill> _bills = new();

        public GetBillQueryHandlerTests()
        {
            _mockRepository = new Mock<IBillRepository>();
            _handler = new GetBillQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidGetBillQueries))]
        public async Task HandlerGetBillCommand_WhenBillExists_ShouldReturnBill(
            GetBillQuery getBillQuery)
        {
            var bill = _bills.First(b => b.Id == getBillQuery.Id);
            _mockRepository.Setup(r => r.GetAsync(getBillQuery.Id)).ReturnsAsync(bill);

            var result = await _handler.Handle(getBillQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(bill);
            _mockRepository.Verify(m => m.GetAsync(getBillQuery.Id), Times.Once);
        }

        public static IEnumerable<object[]> ValidGetBillQueries()
        {
            _bills.AddRange(CreateBillUtils.CreateBills(3));

            foreach (var bill in _bills)
            {
                yield return new[] { new GetBillQuery(bill.Id) };
            }
        }
    }
}
