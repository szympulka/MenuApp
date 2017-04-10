using System;

namespace MenuApp.Services.Models
{
    public class BestFifeRecipesModel
    {
        public string Title { get; set; }
        public int RecipeLikes { get; set; }
        public int RecipeDisLikes { get; set; }
        public int CountComments { get; set; }
        public DateTime DateAdded { get; set; }
        public string ShortDescription { get; set; }
    }
}
