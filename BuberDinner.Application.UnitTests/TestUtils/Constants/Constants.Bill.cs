using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Bill 
        {
            public static readonly BillId Id = BillId.Create(
                Guid.Parse("8c5b01bc-5583-45fe-a858-2c667a80b97d"));
        }
    }
}
