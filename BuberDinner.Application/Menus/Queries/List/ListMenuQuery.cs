using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.Menus.Queries.List
{
    public record ListMenuQuery(HostId HostId) : IRequest<ErrorOr<List<Menu>>>;
}
