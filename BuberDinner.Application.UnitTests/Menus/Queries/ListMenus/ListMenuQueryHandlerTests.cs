using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Queries.List;
using BuberDinner.Application.UnitTests.Menus.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Menu;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Queries.ListMenus
{
    public class ListMenuQueryHandlerTests
    {
        private readonly ListMenuQueryHandler _handler;
        private readonly Mock<IMenuRepository> _mockRepository;
        private static readonly List<Menu> _menus = CreateMenus();

        public ListMenuQueryHandlerTests()
        {
            _mockRepository = new Mock<IMenuRepository>();
            _handler = new ListMenuQueryHandler(_mockRepository.Object);
        }
        [Theory]
        [MemberData(nameof(ValidListMenuQuery))]
        public async Task HandleListMenuQuery_WhenMenusExists_ShouldReturnMenus(
            ListMenuQuery listMenuQuery)
        {
            var menus = _menus.Where(m => m.HostId == listMenuQuery.HostId).ToList();
            _mockRepository.Setup(
                r => r.FindAllAsync(listMenuQuery.HostId))
                    .ReturnsAsync(menus);

            var result = await _handler.Handle(listMenuQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(menus);
            _mockRepository.Verify(m => m.FindAllAsync(listMenuQuery.HostId), Times.Once());
        }

        public static List<Menu> CreateMenus()
        {
            List<Menu> menus = new();

            menus.Add(CreateMenuUtils.CreateMenu());

            menus.Add(CreateMenuUtils.CreateMenu(
                sections: CreateMenuUtils.CreateSections(sectionCount: 3))
            );

            menus.Add(CreateMenuUtils.CreateMenu(
                sections: CreateMenuUtils.CreateSections(
                    sectionCount: 3,
                    items: CreateMenuUtils.CreateItems(itemCount: 3)))
            );

            menus.Add(CreateMenuUtils.CreateMenu(Constants.Host2.Id));

            return menus;
        }

        public static IEnumerable<object[]> ValidListMenuQuery()
        {
            return _menus
                .DistinctBy(menu => menu.HostId)
                .Select(menu => new object[] { new ListMenuQuery(menu.HostId) });
        }
    }
}
