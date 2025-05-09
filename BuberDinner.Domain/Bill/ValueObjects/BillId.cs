﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static BillId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
