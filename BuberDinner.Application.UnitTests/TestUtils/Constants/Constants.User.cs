using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class User
        {
            public static readonly UserId Id = UserId.Create(
                Guid.Parse("497017ac-02a9-4d5f-bc51-ceea636387cd"));
        }
    }
}
