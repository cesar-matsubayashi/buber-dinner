using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class MenuReview
        {
            public static Error NotFound => Error.NotFound(
                code: "MenuReview.NotFound",
                description: "Menu Review not found.");
        }
    }
}
