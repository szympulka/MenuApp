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

            var recipeCategory = _dataContext.All<RecipeCategory>().
                FirstOrDefault(x => x.Cuisine == recipe.Cuisine 
                && x.FoodCateogry == recipe.FoodCategory);

            var Recipe = new Recipe()
            {
                Author = UserHelper.UserName(),
                DateAdded = date.LocalDateTime(),
                IsActive = true,
                Title = recipe.Title,
                Description = recipe.Description,
                ShortDescription = recipe.ShortDescription,
                PreparationTime = recipe.PreparationTime,
                HardLevel = recipe.HardLevel,
            };
            if (recipeCategory != null)
            {
                Recipe.CategoryId = recipeCategory.Id;
            }
            else
            {
                Recipe.IsActive = false;
                var categoryRecipe = new RecipeCategory()
                {
                    ActiveCategory = false,
                    Cuisine = recipe.Cuisine,
                    FoodCateogry = recipe.FoodCategory
                };
                _dataContext.Add<RecipeCategory>(categoryRecipe);
                Recipe.CategoryId = categoryRecipe.Id;               
            }



            foreach (var p in recipe.RecipeComponents)
            {
                if (string.IsNullOrEmpty(p))
                {
                    continue;
                }
                var compsobj = new RecipeComponent();
                compsobj.Name = p;
                var component = _dataContext.All<RecipeComponent>().FirstOrDefault(x => x.Name == p);
                if (component == null)
                {
                    _dataContext.Add<Recipe>(Recipe);
                    _dataContext.Add<RecipeComponent>(compsobj);
                    Recipe.RecipeComponents.Add(compsobj);
                }
                else
                {
                    Recipe.RecipeComponents.Add(component);
                }
            }

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
                model.RecipeCategories.FoodCateogry = editRecipe.Category;
            }
            if (editRecipe.PreparationTime != null)
            {
                model.PreparationTime = editRecipe.PreparationTime;
            }
            if (editRecipe.CategoryOfFood != null)
            {
                model.RecipeCategories.Cuisine = editRecipe.CategoryOfFood;
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
                x => x.Author == component || x.HardLevel == component || x.RecipeCategories.Cuisine == component ||
                x.RecipeCategories.FoodCateogry == component || x.Title == component);
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

        public List<Recipe> SearchByCategory(string category, string categoryOfFOod)
        {
            var model = _dataContext.All<Recipe>().Where(x => x.RecipeCategories.Cuisine == category);
            if (!string.IsNullOrEmpty(categoryOfFOod)) model = model.Where(y => y.RecipeCategories.FoodCateogry == categoryOfFOod);
            return model.ToList();
        }

        public int RandomRecipe()
        {
            var recipe = _dataContext.All<Recipe>().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            return recipe?.Id ?? 0;
        }

        public Dictionary<string, IEnumerable<string>> MenuShow()
        {
            return _dataContext.All<Recipe>().GroupBy(x => x.RecipeCategories.FoodCateogry).ToDictionary(y => y.Key, y => y.Select(z => z.RecipeCategories.Cuisine).Distinct());
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

        public List<RecipeCategory> NewUnacceptedRecipesCategory()
        {
            return _dataContext.All<RecipeCategory>().Where(x => x.ActiveCategory == false).ToList();
        }

        public DetailRecipeModel DetailsRecipe(int id)
        {
            var recipe = _dataContext.All<Recipe>().FirstOrDefault(x => x.Id == id);
            if (recipe == null) return null;
            var detail = new DetailRecipeModel()
            {
                Title = recipe.Title,
                Views = recipe.Views,
                Author = recipe.Author,
                RecipeDisLikes = recipe.RecipeDisLikes,
                RecipeLikes = recipe.RecipeLikes,
                Description = recipe.Description,
                DateAdded = recipe.DateAdded,
                HardLevel = recipe.HardLevel,
                PreparationTime = recipe.PreparationTime
            };

            return null;
        }

        public List<BestFifeRecipesModel> BestFourRecipes(string title)
        {
            title = "Breakfast";
            //TODO::
            List<BestFifeRecipesModel> bestFourRecpiesList = new List<BestFifeRecipesModel>();
            var recipes = _dataContext.All<Recipe>().Where(x=> x.RecipeCategories.FoodCateogry == title && x.IsActive).OrderBy(x => x.RecipeLikes).Take(4).ToList();
            foreach(var model in recipes)
            {
                BestFifeRecipesModel bestFour = new BestFifeRecipesModel();
              //  bestFour.CountComments = _dataContext.All<Recipe>().Where(x => x.Title == model.Title).Count(x => x.Comments != null);
                bestFour.DateAdded = model.DateAdded;
                bestFour.RecipeDisLikes = model.RecipeDisLikes;
                bestFour.RecipeLikes = model.RecipeLikes;
                bestFour.ShortDescription = model.ShortDescription;
                bestFour.Title = model.Title;
                bestFourRecpiesList.Add(bestFour);
            }
            return bestFourRecpiesList;
        }
    }
}