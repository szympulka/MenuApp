using MenuWeb.Core.Entities;
using System.Collections.Generic;

namespace MenuApp.Services.HomeService
{
    public interface IHomeSerivce
    {
        string TimeOfDay();
        List<RecipeCategory> FoodCateogry(string title);
    }
}
