﻿using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockRepository;

        public CreateMenuCommandHandlerTests()
        {
            _mockRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(
            CreateMenuCommand createMenuCommand)
        {
            var result = await _handler.Handle(createMenuCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createMenuCommand);
            _mockRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new[] { CreateMenuCommandUtils.CreateCommand() };

            yield return new[] 
            { 
                CreateMenuCommandUtils.CreateCommand(
                    sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3)) 
            };

            yield return new[]
            {
                CreateMenuCommandUtils.CreateCommand(
                    sections: CreateMenuCommandUtils.CreateSectionsCommand(
                        sectionCount: 3,
                        items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
            };
        }
    }
}
