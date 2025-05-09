using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Queries.ListDinner;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Dinner;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Queries.ListDinners
{
    public class ListDinnersQueryHandlerTests
    {
        private readonly ListDinnersQueryHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;
        private static readonly List<Dinner> _dinners = new(); 

        public ListDinnersQueryHandlerTests()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new ListDinnersQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidListDinnersQuery))]
        public async Task HandleListDinnersQuery_WhenDinnersExists_ShouldReturnDinners(
            ListDinnersQuery listDinnersQuery)
        {
            _mockRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(_dinners);

            var result = await _handler.Handle(listDinnersQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(_dinners);
            _mockRepository.Verify(m => m.GetAllAsync(), Times.Once);
        }


        private static void CreateDinners()
        {
            var dinner = CreateDinnerUtils.CreateDinner();
            dinner.AddReservation(2,
                Constants.Guest.Id,
                Constants.Bill.Id);
            _dinners.Add(dinner);

            var dinner2 = CreateDinnerUtils.CreateDinner(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc));
            dinner.AddReservation(3,
                Constants.Guest.Id,
                Constants.Bill.Id);
            _dinners.Add(dinner2);

            var dinner3 = CreateDinnerUtils.CreateDinner(
                start: new DateTime(2025, 5, 10, 19, 0, 0, DateTimeKind.Utc),
                price: CreateDinnerUtils.CreatePrice(15.99m));
            dinner3.AddReservation(3,
                Constants.Guest.Id,
                Constants.Bill.Id);
            dinner3.AddReservation(2,
                Constants.Guest.Id,
                Constants.Bill.Id);
            _dinners.Add(dinner3);
        }

        public static IEnumerable<object[]> ValidListDinnersQuery()
        {
            CreateDinners();

            yield return new[] { new ListDinnersQuery() };
        }
    }
}
