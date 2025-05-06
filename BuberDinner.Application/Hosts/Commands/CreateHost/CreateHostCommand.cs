using BuberDinner.Domain.Host;
using BuberDinner.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Commands.CreateHost
{
    public record CreateHostCommand(
        string FirstName,
        string LastName,
        string ProfileImage,
        UserId UserId) : IRequest<ErrorOr<Host>>;
}
