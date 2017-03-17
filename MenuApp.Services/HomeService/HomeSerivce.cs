using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.Common.Helpers;

namespace MenuApp.Services.HomeService
{
    public class HomeSerivce: IHomeSerivce
    {
        public string TimeOfDay()
        {
            var date = new DateTimeHelper();
            var localNow = date.LocalDateTime();
            if (localNow.Hour >= 0 && localNow.Hour < 11)
            {
                return "Breakfast";
            }
            if (localNow.Hour >= 11 && localNow.Hour < 15)
            {
                return "Lunch";
            }
            if (localNow.Hour >= 15 && localNow.Hour < 18)
            {
                return "Coffee";
            }
            return "Dinner";
        }

    }
}
