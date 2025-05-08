using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class LocationId : ValueObject
    {
        public Guid Value { get; }

        private LocationId(Guid value)
        {
            Value = value;
        }

        public static LocationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static LocationId CreateUnique(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
