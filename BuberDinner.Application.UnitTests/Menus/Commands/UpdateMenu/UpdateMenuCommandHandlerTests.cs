using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.UpdateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.Menus.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using BuberDinner.Domain.Menu;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommandHandlerTests
    {
        private readonly UpdateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockRepository;
        private static readonly List<Menu> _menus = CreateMenus();

        public UpdateMenuCommandHandlerTests()
        {
            _mockRepository = new Mock<IMenuRepository>();
            _handler = new UpdateMenuCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateMenuCommands))]
        public async Task HandleUpdateMenuCommand_WhenUpdateIsValid_ShouldUpdateAndReturnMenu(
            UpdateMenuCommand updateMenuCommand)
        {
            var menu = _menus.First(m => m.Id == updateMenuCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(updateMenuCommand.Id))
                .ReturnsAsync(menu);

            var result = await _handler.Handle(updateMenuCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateMenuCommand);
            _mockRepository.Verify(m => m.GetAsync(result.Value.Id), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(result.Value), Times.Once);
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

        public static IEnumerable<object[]> ValidUpdateMenuCommands()
        {
            yield return new[] { UpdateMenuCommandUtils.CreateCommand(_menus[2].Id)};

            yield return new[]
            {
                UpdateMenuCommandUtils.CreateCommand(
                    id: _menus[1].Id,
                    sections: UpdateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3))
            };

            yield return new[]
            {
                UpdateMenuCommandUtils.CreateCommand(
                    id: _menus[0].Id,
                    sections: UpdateMenuCommandUtils.CreateSectionsCommand(
                        sectionCount: 3,
                        items: UpdateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
            };
        }
    }
}
