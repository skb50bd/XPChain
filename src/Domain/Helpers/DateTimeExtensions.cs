using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class DateTimeExtensions
    {
        public static string TimeStamp(this DateTime dateTime) =>
            dateTime.ToString("yyyyMMddHHmmssff");
    }
}
