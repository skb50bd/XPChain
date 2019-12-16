using System;

namespace Domain
{
    public static class DateTimeExtensions
    {
        public static string TimeStamp(this DateTime dateTime) =>
            dateTime.ToString("yyyyMMddHHmmssff");
    }
}
