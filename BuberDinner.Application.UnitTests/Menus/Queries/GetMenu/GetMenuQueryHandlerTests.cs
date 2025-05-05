using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Queries.GetMenuById;
using BuberDinner.Application.UnitTests.Menus.TestUtils;
using BuberDinner.Domain.Menu;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Queries.GetMenu
{
    public class GetMenuQueryHandlerTests
    {
        private readonly GetMenuQueryHandler _handler;
        private readonly Mock<IMenuRepository> _mockRepository;
        private static readonly List<Menu> _menus = CreateMenus();

        public GetMenuQueryHandlerTests()
        {
            _mockRepository = new Mock<IMenuRepository>();
            _handler = new GetMenuQueryHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidGetMenuQuery))]
        public async Task HandleGetMenuQuery_WhenMenuExists_ShouldReturnMenu(
            GetMenuQuery getMenuQuery)
        {
            var menu = _menus.First(m => m.Id == getMenuQuery.Id);
            _mockRepository.Setup(r => r.GetAsync(getMenuQuery.Id))
                .ReturnsAsync(menu);

            var result = await _handler.Handle(getMenuQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(menu);
            _mockRepository.Verify(m => m.GetAsync(result.Value.Id), Times.Once);
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

            return menus;
        }

        public static IEnumerable<object[]> ValidGetMenuQuery()
        {
            foreach (var menu in _menus)
            {
                yield return new[] { new GetMenuQuery(menu.Id) } ;
            }
        }
    }
}
