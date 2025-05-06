using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.Create(
                Guid.Parse("5a431314-c743-429c-9c6c-dfc8f966ba79"));

            public const string FirstName = "Tiffany";
            public const string LastName = "Doe";
            public const string ProfileImage = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp";

        }

        public static class Host2
        {
            public static readonly HostId Id = HostId.Create(
                Guid.Parse("aa867785-9073-4b9b-8f1d-19e29cd42116"));

            public const string FirstName = "John";
            public const string LastName = "Ray";
            public const string ProfileImage = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp";
        }
    }
}
