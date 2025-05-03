using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Menu
        {
            public static Error NotFound => Error.NotFound(
                code: "Menu.NotFound",
                description: "Menu not found.");
        }
    }
}
