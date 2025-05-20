using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Bill
        {
            public static Error NotFound => Error.NotFound(
                code: "Bill.NotFound",
                description: "Bill not found.");
        }
    }
}
