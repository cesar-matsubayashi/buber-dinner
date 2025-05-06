using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Queries.GetHost
{
    public record GetHostQuery(HostId Id) : IRequest<ErrorOr<Host>>;
}
