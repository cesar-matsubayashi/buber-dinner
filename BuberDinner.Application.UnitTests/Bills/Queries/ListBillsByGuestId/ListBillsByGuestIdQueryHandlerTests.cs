using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.Bills.Queries.GetBillsByGuestId;
using BuberDinner.Application.UnitTests.Bills.TestUtils;
using BuberDinner.Domain.Bill;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Bills.Queries.ListBillsByGuestId
{
    public class ListBillsByMenuIdQueryHandlerTests
    {
        private readonly ListBillsByGuestIdQueryHandler _handler;
        private readonly Mock<IBillRepository> _mockRepository;
        private static readonly List<Bill> _bills = new();

        public ListBillsByMenuIdQueryHandlerTests()
        {
            _mockRepository = new Mock<IBillRepository>();
            _handler = new ListBillsByGuestIdQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidListBillsByGuestIdQueries))]
        public async Task HandlerListBillsByGuestIdCommand_WhenBillExists_ShouldReturnBill(
            ListBillsByGuestIdQuery listBillsByGuestId)
        {
            _mockRepository.Setup(r => r.GetAllByGuestIdAsync(listBillsByGuestId.GuestId))
                .ReturnsAsync(_bills);

            var result = await _handler.Handle(listBillsByGuestId, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(_bills);
            _mockRepository.Verify(m => m.GetAllByGuestIdAsync(listBillsByGuestId.GuestId), Times.Once);
        }

        public static IEnumerable<object[]> ValidListBillsByGuestIdQueries()
        {
            _bills.AddRange(CreateBillUtils.CreateBills(3));
            _bills.Add(CreateBillUtils.CreateBill(1));

            foreach (var bill in _bills)
            {
                yield return new[] { new ListBillsByGuestIdQuery(bill.GuestId) };
            }
        }
    }
}
