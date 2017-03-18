using System;
using System.Collections.Generic;
using MenuApp.Common.Helpers;
using MenuWeb.Core.Entities;
using MenuApp.Core.Entities;
using System.Linq;

namespace MenuApp.Services.HomeService
{
    public class HomeSerivce : BaseService, IHomeSerivce
    {
        public HomeSerivce(IDataContext dataContext) : base(dataContext)
        {

        }

        public List<RecipeCategory> FoodCateogry(string foodCateogry)
        {
            return _dataContext.All<RecipeCategory>().Where(x => x.FoodCateogry == foodCateogry && x.ActiveCategory).Distinct().ToList();
        }

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
