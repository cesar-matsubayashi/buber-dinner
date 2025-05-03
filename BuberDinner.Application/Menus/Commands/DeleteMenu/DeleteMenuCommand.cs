using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.DeleteMenu
{
    public record DeleteMenuCommand (MenuId Id) : IRequest<ErrorOr<Deleted>>;
}
