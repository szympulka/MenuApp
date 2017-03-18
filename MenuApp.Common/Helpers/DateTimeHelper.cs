using System;

namespace MenuApp.Common.Helpers
{
    public class DateTimeHelper
    {       
        public DateTime LocalDateTime()
        {
            var now = DateTime.UtcNow;
            return TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.Local);
        }

        public  DateTime ServerTime()
        {
            return DateTime.Now;
        }
    }
}
