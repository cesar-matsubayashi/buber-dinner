﻿using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Commands.UpdateMenu;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions
{
    public static partial class MenuExtensions
    {
        public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
        { 
            menu.Name.Should().Be(command.Name);
            menu.Description.Should().Be(command.Description);
            menu.Sections.Should().HaveSameCount(command.Sections);
            menu.Sections.Zip(command.Sections).ToList().ForEach(pair => 
                ValidateSection(pair.First, pair.Second));
        }

        static void ValidateSection(MenuSection section, CreateMenuSectionCommand command)
        {
            section.Id.Should().NotBeNull();
            section.Name.Should().Be(command.Name);
            section.Description.Should().Be(command.Description);
            section.Items.Should().HaveSameCount(command.Items);
            section.Items.Zip(command.Items).ToList().ForEach(pair =>
                ValidateItem(pair.First, pair.Second));
        }

        static void ValidateItem(MenuItem item, CreateMenuItemCommand command)
        {
            item.Id.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.Description.Should().Be(command.Description);
        }

        public static void ValidateUpdatedFrom(this Menu menu, UpdateMenuCommand command)
        {
            menu.Name.Should().Be(command.Name);
            menu.Description.Should().Be(command.Description);
            menu.Sections.Should().HaveSameCount(command.Sections);
            menu.Sections.Zip(command.Sections).ToList().ForEach(pair =>
                ValidateSection(pair.First, pair.Second));
        }

        static void ValidateSection(MenuSection section, UpdateMenuSectionCommand command)
        {
            section.Id.Should().NotBeNull();
            section.Name.Should().Be(command.Name);
            section.Description.Should().Be(command.Description);
            section.Items.Should().HaveSameCount(command.Items);
            section.Items.Zip(command.Items).ToList().ForEach(pair =>
                ValidateItem(pair.First, pair.Second));
        }

        static void ValidateItem(MenuItem item, UpdateMenuItemCommand command)
        {
            item.Id.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.Description.Should().Be(command.Description);
        }
    }
}
