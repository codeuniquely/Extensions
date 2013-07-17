namespace System
{
    using System.Globalization;

    /// <summary>
    /// Extension to DateTime to allow check for a constant default Date value
    /// </summary>
    public static class DateTimeExt
    {
        /// <summary>
        /// Make a choice for default Date and then stick with it 
        /// This value works for both DateTime and DateTime2 (SQL 2005 / 2008 / 2008 R2)
        /// It also works well on Frameworks Net 3.5 and 4.0
        /// </summary>
        private static readonly DateTime defaultDateTime = new DateTime(1753, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets the default Date Time for use in querires
        /// </summary>
        public static DateTime Default
        {
            get { return defaultDateTime; }
        }

        /// <summary>
        /// Determines whether the specified date is default.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the specified date is default; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDefault(this DateTime date)
        {
            return date == DateTime.MinValue;
        }


        public static string ToLocale(this DateTime source)
        {
            DateTimeFormatInfo format = CultureInfo.CurrentCulture.DateTimeFormat;
            return source.ToString(string.Concat(format.LongDatePattern, " ", format.ShortTimePattern));
        }


        /// <summary>
        /// COnverts display format to Localised version
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToLocaleShortFormat(this DateTime source)
        {
            DateTimeFormatInfo format = CultureInfo.CurrentCulture.DateTimeFormat;
            return source.ToString(format.ShortDatePattern);
        }

        public static string ToDateLocale(this DateTime source)
        {
            DateTimeFormatInfo format = CultureInfo.CurrentCulture.DateTimeFormat;
            return source.ToString(format.LongDatePattern);
        }

        /// <summary>
        /// Returns the specified date as ISO8601 string.
        /// Only UTC times are supported
        /// </summary>
        /// <param name="source">A DateTime in UTC</param>
        /// <returns>
        /// The datetime as an ISO8601 string
        /// </returns>
        public static string ToISO8601String(this DateTime source)
        {
            return source.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Date(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Time(this DateTime dt)
        {
            return new DateTime(0, 0, 0, dt.Hour, dt.Minute, dt.Second);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Midday(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            DayOfWeek firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            while (dt.DayOfWeek != firstDayOfWeek)
            {
                dt = dt.AddDays(-1);
            }

            return dt;
        }

        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(7);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return dt.AddDays((-dt.Day) + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.AddDays((-dt.Day) - 1).AddMonths(1);
        }
    }
}
