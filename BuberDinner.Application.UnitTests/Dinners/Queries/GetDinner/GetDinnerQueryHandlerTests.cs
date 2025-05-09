using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Dinners.Queries.GetDinner;
using BuberDinner.Application.Hosts.Queries.GetHost;
using BuberDinner.Application.UnitTests.Dinners.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Dinner;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Dinners.Queries.GetDinner
{
    public class GetDinnerQueryHandlerTests
    {
        private readonly GetDinnerQueryHandler _handler;
        private readonly Mock<IDinnerRepository> _mockRepository;
        private static readonly List<Dinner> _dinners = new(); 

        public GetDinnerQueryHandlerTests()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _handler = new GetDinnerQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidGetDinnerQuery))]
        public async Task HandleGetDinnerQuery_WhenDinnerExists_ShouldReturnDinner(
            GetDinnerQuery getDinnerQuery)
        {
            var dinner = _dinners.First(m => m.Id == getDinnerQuery.Id);
            _mockRepository.Setup(r => r.GetAsync(getDinnerQuery.Id))
                .ReturnsAsync(dinner);

            var result = await _handler.Handle(getDinnerQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(dinner);
            _mockRepository.Verify(m => m.GetAsync(result.Value.Id), Times.Once);
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

        public static IEnumerable<object[]> ValidGetDinnerQuery()
        {
            CreateDinners();

            foreach (var dinner in _dinners)
            {
                yield return new[] { new GetDinnerQuery(dinner.Id) };
            }
        }
    }
}
