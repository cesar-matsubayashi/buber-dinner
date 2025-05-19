using BuberDinner.Application.Bills.Commands.CreateBill;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.Bills.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Bills.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Bills.Commands.CreateBill
{
    public class CreateBillCommandHandlerTests
    {
        private readonly CreateBillCommandHandler _handler;
        private readonly Mock<IBillRepository> _mockRepository;

        public CreateBillCommandHandlerTests()
        {
            _mockRepository = new Mock<IBillRepository>();
            _handler = new CreateBillCommandHandler(_mockRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateBillCommands))]
        public async Task HandleCreateBillCommand_WhenBillIsValid_ShouldCreateAndReturnBill(
            CreateBillCommand createBillCommand)
        {
            var result = await _handler.Handle(createBillCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createBillCommand);
            _mockRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateBillCommands()
        {
            yield return new[] { CreateBillCommandUtils.CreateCommand() };
        }
    }

}
