using System.Collections.Generic;
using MenuApp.Core.Entities;

namespace MenuApp.Services.Models.RecipeModel
{
    public class AdvanceSearchViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public int ComponentsMatched { get; set; }
    }
}