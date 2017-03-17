using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
