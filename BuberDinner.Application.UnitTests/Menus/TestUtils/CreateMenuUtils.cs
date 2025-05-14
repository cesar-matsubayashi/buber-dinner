using BuberDinner.Application.Menus.Queries.GetMenuById;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;

namespace BuberDinner.Application.UnitTests.Menus.TestUtils
{
    public static class CreateMenuUtils
    {
        public static Menu CreateMenu(
            HostId hostId = null!,
            List<MenuSection>? sections = null) => 
            Menu.Create(
                hostId is null ? Constants.Host.Id1 : hostId,
                Constants.Menu.Name,
                Constants.Menu.Description,
                sections ?? CreateSections()
          );

        public static List<MenuSection> CreateSections(
            int sectionCount = 1,
            List<MenuItem>? items = null) =>
            Enumerable.Range(0, sectionCount)
                .Select(index => MenuSection.Create(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDescriptionFromIndex(index),
                    items ?? CreateItems()))
                .ToList();

        public static List<MenuItem> CreateItems(int itemCount = 1) =>
            Enumerable.Range(0, itemCount)
                .Select(index => MenuItem.Create(
                    Constants.Menu.ItemNameFromIndex(index),
                    Constants.Menu.ItemDescriptionFromIndex(index)))
                .ToList();
    }
}
