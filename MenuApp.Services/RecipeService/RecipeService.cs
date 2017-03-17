using System.Collections.Generic;
using MenuApp.Core.Entities;
using MenuApp.Services.Models.RecipeModel;
using System.Linq;
using System.Web;
using MenuApp.Common.Helpers;
using System;
using System.Data.Entity;
using MenuApp.Services.Models;
using MenuWeb.Core.Entities;


namespace MenuApp.Services.RecipeService
{
    public class RecipeService : BaseService, IRecipeService
    {
        public RecipeService(IDataContext dataContext) : base(dataContext)
        {
        }
        public void AddRecipe(AddRecipeModel recipe, HttpPostedFileBase file)
        {
            var date = new DateTimeHelper();
            var Recipe = new Recipe()
            {
                Author = UserHelper.UserName(),
                DateAdded = date.LocalDateTime(),
                IsActive = true,
                Title = recipe.Title,
                Description = recipe.Description,
                ShortDescription = recipe.ShortDescription,
                Category = recipe.Category,
                CategoryOfFood = recipe.CategoryOfFood,
                PreparationTime = recipe.PreparationTime,
                HardLevel = recipe.HardLevel,

            };

            _dataContext.Add<Recipe>(Recipe);
            _dataContext.SaveChanges();
            FileAzureUploaderHelper.UploadPhoto(recipe.Title, file);
        }
        public bool EditRecipe(EditeRecipeModel editRecipe)
        {
            if (string.IsNullOrEmpty(editRecipe.Title) && string.IsNullOrEmpty(editRecipe.Category) &&
           string.IsNullOrEmpty(editRecipe.Description) && editRecipe.PreparationTime == null) return false;
            var model = _dataContext.All<Recipe>().First(x => x.Id == editRecipe.Id);
            if (model == null) return false;
            if (!string.IsNullOrEmpty(editRecipe.Title))
            {
                model.Title = editRecipe.Title;
            }
            if (!string.IsNullOrEmpty(editRecipe.Description))
            {
                model.Description = editRecipe.Description;
            }
            if (!string.IsNullOrEmpty(editRecipe.Category))
            {
                model.Category = editRecipe.Category;
            }
            if (editRecipe.PreparationTime != null)
            {
                model.PreparationTime = editRecipe.PreparationTime;
            }
            if (editRecipe.CategoryOfFood != null)
            {
                model.CategoryOfFood = editRecipe.CategoryOfFood;
            }
            //drop-down list edit
            model.IsActive = editRecipe.IsActive;
            _dataContext.SaveChanges();
            return true;
        }
        public List<Recipe> FindRecipes(string component)
        {
            var model = _dataContext.All<Recipe>().AsQueryable();
            model = _dataContext.All<Recipe>().Where(
                x => x.Author == component || x.HardLevel == component || x.Category == component ||
                x.CategoryOfFood == component || x.Title == component);
            return model.ToList();

        }
        public List<Recipe> NewRecipes()
        {
            var count = _dataContext.All<Recipe>().Count();
            return count < 5 ? null : _dataContext.All<Recipe>().OrderBy(x => x.Id).Skip(count - 5).Take(5).ToList();
        }
        public void RemoveRecipe(int id)
        {
            var model = _dataContext.Find<Recipe>(id);
            _dataContext.Remove<Recipe>(model);
            _dataContext.SaveChanges();
        }
        public Recipe DetailRecipe(int id)
        {
            return _dataContext.Find<Recipe>(id);
        }
        public List<Recipe> ShowRecipes()
        {
            return _dataContext.All<Recipe>().AsNoTracking().ToList();
        }
        public void SubstitutionActive(SubstitutionActiveModel recipeModel)
        {
            _dataContext.Find<Recipe>(recipeModel.Id).IsActive = !recipeModel.IsActive;
            _dataContext.SaveChanges();
        }
        public List<Recipe> BestFiveRecipes()
        {
            return _dataContext.All<Recipe>().OrderByDescending(x => x.RecipeLikes).Take(5).ToList();
        }

        public List<Recipe> SearchByCategory(string category, string categoryOfFOod)
        {
            var model = _dataContext.All<Recipe>().Where(x => x.Category == category);
            if (!string.IsNullOrEmpty(categoryOfFOod)) model = model.Where(y => y.CategoryOfFood == categoryOfFOod);
            return model.ToList();
        }

        public int RandomRecipe()
        {
            var recipe = _dataContext.All<Recipe>().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            return recipe?.Id ?? 0;
        }

        public Dictionary<string, IEnumerable<string>> MenuShow()
        {
            return _dataContext.All<Recipe>().GroupBy(x => x.Category).ToDictionary(y => y.Key, y => y.Select(z => z.CategoryOfFood).Distinct());
        }

        public void AddLike(int id)
        {
            _dataContext.Find<Recipe>(id).RecipeLikes++;
            var like = new RecipeLike
            {
                IdRecipe = id,
                UserName = UserHelper.UserName(),
            };
            _dataContext.Add<RecipeLike>(like);
            _dataContext.SaveChanges();
        }

        public void RemoveLike(int id, string userName)
        {
            var like = _dataContext.All<RecipeLike>().FirstOrDefault(x => x.IdRecipe == id && x.UserName == userName);
            if (like == null) return;
            _dataContext.Remove<RecipeLike>(like);
            _dataContext.Find<Recipe>(id).RecipeLikes--;
            _dataContext.SaveChanges();
        }

        public bool UsersLikeRecipe(int id)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return false;
            string userName = UserHelper.UserName();
            var like = _dataContext.All<RecipeLike>().FirstOrDefault(x => x.IdRecipe == id && x.UserName == userName);
            return like != null;
        }

        public string CheckRecipeTitleExist(string title)
        {
            var recipeName = _dataContext.All<Recipe>().FirstOrDefault(x => x.Title == title);
            return recipeName != null ? "True" : "False";
        }

        public List<Recipe> BreakfastMenuShow()
        {
            return _dataContext.All<Recipe>().Where(x => x.CategoryOfFood == "Breakfast").Distinct().ToList();
        }
    }
}