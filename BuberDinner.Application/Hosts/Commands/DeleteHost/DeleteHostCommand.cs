using BuberDinner.Domain.Host.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Commands.DeleteHost
{
    public record DeleteHostCommand(HostId Id) : IRequest<ErrorOr<Deleted>>;
}
