using BuberDinner.Application.Menus.Commands.UpdateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils
{
    public static class UpdateMenuCommandUtils
    {
        public static UpdateMenuCommand CreateCommand(
            MenuId id,
            List<UpdateMenuSectionCommand>? sections = null) =>
            new UpdateMenuCommand(
                id,
                Constants.Menu2.Name,
                Constants.Menu2.Description,
                sections ?? CreateSectionsCommand()
            );

        public static List<UpdateMenuSectionCommand> CreateSectionsCommand(
            int sectionCount = 1,
            List<UpdateMenuItemCommand>? items = null) =>
            Enumerable.Range( 0, sectionCount )
                .Select(index => new UpdateMenuSectionCommand(
                    Constants.Menu2.SectionNameFromIndex(index),
                    Constants.Menu2.SectionDescriptionFromIndex(index),
                    items ?? CreateItemsCommand()))
                .ToList();

        public static List<UpdateMenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
            Enumerable.Range ( 0, itemCount )
                .Select(index => new UpdateMenuItemCommand(
                    Constants.Menu2.ItemNameFromIndex(index),
                    Constants.Menu2.ItemDescriptionFromIndex(index)))
                .ToList();
    }       
}
