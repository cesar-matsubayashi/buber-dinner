using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Hosts.Commands.DeleteHost;
using BuberDinner.Application.UnitTests.Hosts.TestUtils;
using BuberDinner.Domain.Host;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Hosts.Commands.DeleteHost
{
    public class DeleteHostCommandHandlerTests
    {
        private readonly DeleteHostCommandHandler _handler;
        private readonly Mock<IHostRepository> _mockRepository;
        private static readonly List<Host> _hosts = CreateHosts();

        public DeleteHostCommandHandlerTests()
        {
            _mockRepository = new Mock<IHostRepository>();
            _handler = new DeleteHostCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidDeleteHostCommand))]
        public async Task HandleDeleteHostCommand_WhenHostExists_ShouldDeleteHostAndRetunNoContent(
            DeleteHostCommand deleteHostCommand)
        {
            var host = _hosts.First(m => m.Id == deleteHostCommand.Id);
            _mockRepository.Setup(r => r.GetAsync(deleteHostCommand.Id))
                .ReturnsAsync(host);

            var result = await _handler.Handle(deleteHostCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Deleted>();
            _mockRepository.Verify(m => m.GetAsync(deleteHostCommand.Id), Times.Once);
            _mockRepository.Verify(m => m.DeleteAsync(deleteHostCommand.Id), Times.Once);
        }

        public static List<Host> CreateHosts()
        {
            List<Host> hosts = new();

            hosts.Add(CreateHostUtils.CreateHost());

            return hosts;
        }

        public static IEnumerable<object[]> ValidDeleteHostCommand()
        {
            foreach (var host in _hosts)
            {
                yield return new[] { new DeleteHostCommand(host.Id) };
            }
        }
    }
}
