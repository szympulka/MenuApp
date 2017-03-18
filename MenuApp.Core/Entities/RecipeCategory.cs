using MenuApp.Core.Entities;
using System.Collections.Generic;

namespace MenuWeb.Core.Entities
{
    public class RecipeCategory
    {
        
        public int Id { get; set; }
        public string FoodCateogry { get; set; }
        public string Cuisine { get; set; }
        public bool ActiveCategory { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
