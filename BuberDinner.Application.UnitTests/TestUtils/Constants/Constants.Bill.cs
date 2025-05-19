using BuberDinner.Domain.Bill.ValueObjects;

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

            public const decimal PriceAmount1 = 10.99m;
            public const string PriceCurrency1 = "USD";
            
            public const decimal PriceAmount2 = 10.99m;
            public const string PriceCurrency2 = "USD";
            
            public const decimal PriceAmount3 = 10.99m;
            public const string PriceCurrency3 = "USD";
        }
    }
}
