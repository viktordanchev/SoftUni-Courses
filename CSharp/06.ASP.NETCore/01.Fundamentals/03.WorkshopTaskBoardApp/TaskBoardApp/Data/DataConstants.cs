namespace TaskBoardApp.Data
{
    public static class DataConstants
    {
        public static class Task
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class Board
        {
            public const int BoardMinLength = 3;
            public const int BoardMaxLength = 30;
        }
    }
}
