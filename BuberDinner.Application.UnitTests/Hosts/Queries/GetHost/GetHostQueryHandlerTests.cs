using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Hosts.Queries.GetHost;
using BuberDinner.Application.UnitTests.Hosts.TestUtils;
using BuberDinner.Domain.Host;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Hosts.Queries.GetHost
{
    public class GetHostQueryHandlerTests
    {
        private readonly GetHostQueryHandler _handler;
        private readonly Mock<IHostRepository> _mockRepository;
        private readonly Mock<IMenuRepository> _mockMenuRepository;
        private static readonly List<Host> _hosts = CreateHosts();

        public GetHostQueryHandlerTests()
        {
            _mockRepository = new Mock<IHostRepository>();
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new GetHostQueryHandler(
                _mockRepository.Object,
                _mockMenuRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidGetHostQuery))]
        public async Task HandleGetHostQuery_WhenHostExists_ShouldReturnHost(
            GetHostQuery getHostQuery)
        {
            var host = _hosts.First(m => m.Id == getHostQuery.Id);
            _mockRepository.Setup(r => r.GetAsync(getHostQuery.Id))
                .ReturnsAsync(host);
            _mockMenuRepository.Setup(r => r.GetAllMenuIdsByHostId(host.Id))
                .ReturnsAsync([]);

            var result = await _handler.Handle(getHostQuery, default);

            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(host);
            _mockRepository.Verify(m => m.GetAsync(result.Value.Id), Times.Once);
        }

        public static List<Host> CreateHosts()
        {
            List<Host> hosts = new();

            hosts.Add(CreateHostUtils.CreateHost());
            
            return hosts;
        }

        public static IEnumerable<object[]> ValidGetHostQuery()
        {
            foreach (var host in _hosts)
            {
                yield return new[] { new GetHostQuery(host.Id) };
            }
        }
    }
}
