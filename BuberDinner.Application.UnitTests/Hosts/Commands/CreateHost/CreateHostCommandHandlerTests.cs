using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Hosts.Commands.CreateHost;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Application.UnitTests.TestUtils.Hosts.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Hosts.Commands.CreateHost
{
    public class CreateHostCommandHandlerTests
    {
        private readonly CreateHostCommandHandler _handler;
        private readonly Mock<IHostRepository> _mockRepository;

        public CreateHostCommandHandlerTests()
        {
            _mockRepository = new Mock<IHostRepository>();
            _handler = new CreateHostCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateHostCommands))]
        public async Task HandleCreateHostCommand_WhenHostIsValid_ShouldCreateAndReturnHost(
            CreateHostCommand createHostCommand)
        {
            var result = await _handler.Handle(createHostCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createHostCommand);
            _mockRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateHostCommands()
        {
            yield return new[]
            {
                new CreateHostCommand(
                    Constants.Host.FirstName,
                    Constants.Host.LastName,
                    Constants.Host.ProfileImage,
                    Constants.User.Id1)
            };
        }
    }
}
