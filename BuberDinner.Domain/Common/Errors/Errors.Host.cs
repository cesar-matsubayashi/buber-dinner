using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Host
        {
            public static Error NotFound => Error.NotFound(
                code: "Host.NotFound",
                description: "Host not found.");
        }
    }
}
