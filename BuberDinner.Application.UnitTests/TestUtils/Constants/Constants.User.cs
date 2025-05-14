using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class User
        {
            public static readonly UserId Id1 = UserId.Create(
                Guid.Parse("497017ac-02a9-4d5f-bc51-ceea636387cd"));

            public static readonly UserId Id2 = UserId.Create(
               Guid.Parse("a5e57a5b-4b88-4458-9ba3-b1363c164f40"));

            public static readonly UserId Id3 = UserId.Create(
               Guid.Parse("7133c539-bedc-4381-91a8-fe4e5df8be59"));
        }
    }
}
