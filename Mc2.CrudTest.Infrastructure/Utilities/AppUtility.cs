using System.Globalization;

namespace Mc2.CrudTest.Infrastructure.Utilities
{
    public static class AppUtility
    {

        public static bool IsWeekend(this DateTime dateTime)
        {
            return (dateTime.DayOfWeek == DayOfWeek.Saturday ||
                    dateTime.DayOfWeek == DayOfWeek.Sunday);
        }


        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}
