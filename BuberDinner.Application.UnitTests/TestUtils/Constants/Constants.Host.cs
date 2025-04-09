using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.Create(
                Guid.Parse("5a431314-c743-429c-9c6c-dfc8f966ba79"));
        }
    }
}
