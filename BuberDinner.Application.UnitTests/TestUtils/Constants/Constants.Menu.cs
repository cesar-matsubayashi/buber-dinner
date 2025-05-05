namespace BuberDinner.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Menu
        {
            public const string Name = "Menu Name";
            public const string Description = "Menu Description";
            public const string SectionName = "Menu Section Name";
            public const string SectionDescription = "Menu Section Description";
            public const string ItemName = "Menu Item Name";
            public const string ItemDescription = "Menu Item Description";

            public static string  SectionNameFromIndex(int index) 
                => $"{SectionName} {index}";

            public static string SectionDescriptionFromIndex(int index)
               => $"{SectionDescription} {index}";

            public static string ItemNameFromIndex(int index)
               => $"{ItemName} {index}";

            public static string ItemDescriptionFromIndex(int index)
               => $"{ItemDescription} {index}";
        }

        public static class Menu2
        {
            public const string Name = "Menu Name 2";
            public const string Description = "Menu Description 2";
            public const string SectionName = "Menu Section Name 2";
            public const string SectionDescription = "Menu Section Description 2";
            public const string ItemName = "Menu Item Name 2";
            public const string ItemDescription = "Menu Item Description 2";

            public static string SectionNameFromIndex(int index)
                => $"{SectionName} {index}";

            public static string SectionDescriptionFromIndex(int index)
               => $"{SectionDescription} {index}";

            public static string ItemNameFromIndex(int index)
               => $"{ItemName} {index}";

            public static string ItemDescriptionFromIndex(int index)
               => $"{ItemDescription} {index}";
        }
    }
}
