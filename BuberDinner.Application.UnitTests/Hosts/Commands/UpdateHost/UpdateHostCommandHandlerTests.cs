using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Hosts.Commands.UpdateHost;
using BuberDinner.Application.UnitTests.Hosts.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.Hosts.Extensions;
using BuberDinner.Domain.Host;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Hosts.Commands.UpdateHost
{
    public class UpdateHostCommandHandlerTests
    {
        private readonly UpdateHostCommandHandler _handler;
        private readonly Mock<IHostRepository> _mockRepository;
        private static readonly List<Host> _hosts = CreateHosts();

        public UpdateHostCommandHandlerTests()
        {
            _mockRepository = new Mock<IHostRepository>();
            _handler = new UpdateHostCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidUpdateMenuCommands))]
        public async Task HandleUpdateHostCommand_WhenUpdateIsValid_ShouldUpdateAndReturnHost(
            UpdateHostCommand updateHostCommand)
        {
            var host = _hosts.First(h => h.Id == updateHostCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(updateHostCommand.Id))
            .ReturnsAsync(host);

            var result = await _handler.Handle(updateHostCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateUpdatedFrom(updateHostCommand);
            _mockRepository.Verify(m => m.GetAsync(result.Value.Id), Times.Once);
            _mockRepository.Verify(m => m.UpdateAsync(result.Value), Times.Once);
        }

        public static List<Host> CreateHosts()
        {
            List<Host> hosts = new();

            hosts.Add(CreateHostUtils.CreateHost());

            return hosts;
        }

        public static IEnumerable<object[]> ValidUpdateMenuCommands()
        {
            yield return new[]
            {
                new UpdateHostCommand(
                    _hosts[0].Id,
                    Constants.Host.FirstName1,
                    Constants.Host.LastName1,
                    Constants.Host.ProfileImage1)
            };
        }
    }
}
