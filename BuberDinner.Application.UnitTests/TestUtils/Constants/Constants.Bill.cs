using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Bill 
        {
            public static readonly BillId Id1 = BillId.Create(
                Guid.Parse("8c5b01bc-5583-45fe-a858-2c667a80b97d"));

            public static readonly BillId Id2 = BillId.Create(
                Guid.Parse("2c19cd85-a5cd-4c51-a546-3eb22dcce19d"));

            public static readonly BillId Id3 = BillId.Create(
                Guid.Parse("1a68edd3-9a71-4f77-8a8a-0ad174775005"));
        }
    }
}
