using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id1 = HostId.Create(
                Guid.Parse("5a431314-c743-429c-9c6c-dfc8f966ba79"));
            public const string FirstName1 = "Tiffany";
            public const string LastName1 = "Doe";
            public const string ProfileImage1 = "https://www.gravatar.com/avatar/1";

            public static readonly HostId Id2 = HostId.Create(
                Guid.Parse("7267981c-b68b-4324-a99c-6392260a8d62"));
            public const string FirstName2 = "John";
            public const string LastName2 = "Ray";
            public const string ProfileImage2 = "https://www.gravatar.com/avatar/2";

            public static readonly HostId Id3 = HostId.Create(
                Guid.Parse("05205549-be11-4e8e-862c-205736a4850f"));
            public const string FirstName3 = "Janna";
            public const string LastName3 = "Sutton";
            public const string ProfileImage3 = "https://www.gravatar.com/avatar/3";

        }
    }
}
