using System;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int GetDifference(string firstDate, string secondDate)
        {
            DateTime firstDateTime = DateTime.Parse(firstDate);
            DateTime secondDateTime = DateTime.Parse(secondDate);

            TimeSpan difference = firstDateTime - secondDateTime;

            return Math.Abs(difference.Days);
        }
    }
}