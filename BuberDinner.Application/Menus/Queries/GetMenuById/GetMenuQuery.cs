using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetMenuById
{
    public record GetMenuQuery(MenuId MenuId) : IRequest<ErrorOr<Menu>>; 
}
