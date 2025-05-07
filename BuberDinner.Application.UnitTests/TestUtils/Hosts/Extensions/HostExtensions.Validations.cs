using BuberDinner.Application.Hosts.Commands.CreateHost;
using BuberDinner.Application.Hosts.Commands.UpdateHost;
using BuberDinner.Domain.Host;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Hosts.Extensions
{
    public static partial class HostExtensions
    {
        public static void ValidateCreatedFrom(this Host host, CreateHostCommand command)
        { 
            host.FirstName.Should().Be(command.FirstName);
            host.LastName.Should().Be(command.LastName);
            host.ProfileImage.Should().Be(command.ProfileImage);
            host.UserId.Should().Be(command.UserId);
        }

        public static void ValidateUpdatedFrom(this Host host, UpdateHostCommand command)
        {
            host.FirstName.Should().Be(command.FirstName);
            host.LastName.Should().Be(command.LastName);
            host.ProfileImage.Should().Be(command.ProfileImage);
        }
    }
}
