using MenuApp.Core.Entities;

namespace MenuApp.Services.Models.RecipeModel
{
    public class DetailRecipe
    {
        public bool UsersLikeRecipe { get; set; }
        public Recipe Recipe { get; set; }
    }
}