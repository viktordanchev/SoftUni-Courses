namespace GameZone.Data
{
    public static class DataConstants
    {
        public static class Game
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const string DateAndTimeFormat = "yyyy-MM-dd";
        }

        public static class Genre
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 25;
        }
    }
}
