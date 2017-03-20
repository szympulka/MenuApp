using MenuApp.Core.Entities;
using MenuApp.Services.Models.RecipeModel;
using System.Collections.Generic;
using System.Web;
using MenuApp.Services.Models;
using MenuWeb.Core.Entities;

namespace MenuApp.Services.RecipeService
{
    public interface IRecipeService
    {
        void AddRecipe(AddRecipeModel recipe, HttpPostedFileBase file);
        List<Recipe> ShowRecipes();
        Recipe DetailRecipe(int id);
        List<Recipe> FindRecipes(string component);
        void RemoveRecipe(int id);
        void SubstitutionActive(SubstitutionActiveModel recipeModel);
        List<Recipe> NewRecipes();
        bool EditRecipe(EditeRecipeModel editRecipe);
        List<Recipe> BestFiveRecipes();
        List<Recipe> SearchByCategory(string category, string categoryOfFOod);
        int RandomRecipe();
        Dictionary<string, IEnumerable<string>> MenuShow();
        void AddLike(int id);
        void RemoveLike(int id, string userName);
        bool UsersLikeRecipe(int id);
        string CheckRecipeTitleExist(string title);
        List<RecipeCategory> NewUnacceptedRecipesCategory();
        DetailRecipeModel DetailsRecipe(int id);
    }
}