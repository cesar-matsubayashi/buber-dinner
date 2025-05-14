using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Guest
        {
            public static Error NotFound => Error.NotFound(
                code: "Guest.NotFound",
                description: "Guest not found.");
        }
    }
}
