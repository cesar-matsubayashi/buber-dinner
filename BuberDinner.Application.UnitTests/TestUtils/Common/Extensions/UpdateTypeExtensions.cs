namespace BuberDinner.Application.UnitTests.TestUtils.Common.Extensions
{
    public static class UpdateTypeExtensions
    {
        public static string Update(this string value) => $"{value} Updated";

        public static int Update(this int value) => value + 1;
        
        public static decimal Update(this decimal value) => value + 1;
        
        public static float Update(this float value) => value + 1;

        public static DateTime Update(this DateTime value) => value.AddDays(1);


    }
}
