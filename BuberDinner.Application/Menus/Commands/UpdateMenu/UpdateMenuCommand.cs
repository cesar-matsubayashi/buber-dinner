using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.UpdateMenu
{
    public record UpdateMenuCommand(
        Guid id,
        string Name,
        string Description,
        List<UpdateMenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

    public record UpdateMenuSectionCommand(
        string Name,
        string Description,
        List<UpdateMenuItemCommand> Items);

    public record UpdateMenuItemCommand(
        string Name,
        string Description);
}
