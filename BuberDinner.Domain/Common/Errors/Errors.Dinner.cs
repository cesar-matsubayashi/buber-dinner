using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Dinner
        {
            public static Error NotFound => Error.NotFound(
                code: "Dinner.NotFound",
                description: "Dinner not found.");
        }
    }
}
