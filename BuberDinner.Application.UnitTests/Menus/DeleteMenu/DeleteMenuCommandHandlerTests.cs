using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.DeleteMenu;
using BuberDinner.Application.UnitTests.Menus.TestUtils;
using BuberDinner.Domain.Menu;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.DeleteMenu
{
    public class DeleteMenuCommandHandlerTests
    {
        private readonly DeleteMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockRepository;
        private static readonly List<Menu> _menus = CreateMenus();

        public DeleteMenuCommandHandlerTests()
        {
            _mockRepository = new Mock<IMenuRepository>();
            _handler = new DeleteMenuCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidDeleteMenuCommand))]
        public async Task HandleDeleteMenuCommand_WhenMenuExists_ShouldDeleteMenuAndRetunNoContent(
            DeleteMenuCommand deleteMenuCommand)
        {
            var menu = _menus.First(m => m.Id == deleteMenuCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(deleteMenuCommand.Id))
                .ReturnsAsync(menu);

            var result = await _handler.Handle(deleteMenuCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Deleted>();
            _mockRepository.Verify(m => m.GetAsync(deleteMenuCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.DeleteAsync(deleteMenuCommand.Id), Times.Once);

        }

        public static List<Menu> CreateMenus()
        {
            List<Menu> menus = new();

            menus.Add(CreateMenuUtils.CreateMenu());

            menus.Add(CreateMenuUtils.CreateMenu(
                sections: CreateMenuUtils.CreateSections(
                    sectionCount: 3,
                    items: CreateMenuUtils.CreateItems(itemCount: 3)))
            );

            return menus;
        }

        public static IEnumerable<object[]>ValidDeleteMenuCommand()
        {
            foreach (var menu in _menus)
            {
                yield return new[] { new DeleteMenuCommand(menu.Id) };
            }
        }
    }
}
