using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Guest
        {
            public static readonly GuestId Id1 = GuestId.Create(
                Guid.Parse("7613f603-524d-4cce-8884-8b484a11839c"));

            public static readonly GuestId Id2 = GuestId.Create(
                Guid.Parse("ef040a77-d5c4-4c37-8046-461d3b0a734c"));

            public static readonly GuestId Id3 = GuestId.Create(
                Guid.Parse("b0123d9e-70ba-4a08-a61c-943e401273d7"));
        }
    }
}
