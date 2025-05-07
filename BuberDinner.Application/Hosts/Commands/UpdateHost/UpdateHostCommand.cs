using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Commands.UpdateHost
{
    public record UpdateHostCommand(
        HostId Id,
        string FirstName,
        string LastName,
        string ProfileImage) : IRequest<ErrorOr<Host>>;
}
