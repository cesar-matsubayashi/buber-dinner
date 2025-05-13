using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Guest
        {
            public static readonly GuestId Id1 = GuestId.Create(
                Guid.Parse("7613f603-524d-4cce-8884-8b484a11839c"));
            public const string FirstName1 = "Tiffany";
            public const string LastName1 = "Doe";
            public const string ProfileImage1 = 
                "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp";
            
            public static readonly GuestId Id2 = GuestId.Create(
                Guid.Parse("ef040a77-d5c4-4c37-8046-461d3b0a734c"));
            public const string FirstName2 = "John";
            public const string LastName2 = "Wilcox";
            public const string ProfileImage2 = 
                "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp";

            public static readonly GuestId Id3 = GuestId.Create(
                Guid.Parse("b0123d9e-70ba-4a08-a61c-943e401273d7"));
            public const string FirstName3 = "Chloe";
            public const string LastName3 = "Frye";
            public const string ProfileImage3 = 
                "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp";
        }

        public static class GuestRating
        {
            public const float Rating1 = 4.9f;

            public const float Rating2 = 4.7f;

            public const float Rating3 = 4.5f;
        }
    }
}
