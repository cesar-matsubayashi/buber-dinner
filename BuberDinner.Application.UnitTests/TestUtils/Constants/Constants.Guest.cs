using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Guest
        {
            public static readonly GuestId Id = GuestId.Create(
                Guid.Parse("7613f603-524d-4cce-8884-8b484a11839c"));
        }
    }
}
