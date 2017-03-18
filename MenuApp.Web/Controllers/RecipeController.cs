using System.Web.Mvc;
using MenuApp.Services.Models.RecipeModel;
using MenuApp.Services.RecipeService;
using System.Web;
using MenuApp.Common.Helpers;
using MenuApp.Services.Models;
using PagedList;

namespace MenuApp.Web.Controllers
{
    //    [Common.Attributes.Authorize(Role = "Admin")]
    public class RecipeController : Controller
    {
  
        private IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public ActionResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRecipe(AddRecipeModel recipe, HttpPostedFileBase file)
        {
            _recipeService.AddRecipe(recipe, file);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ShowRecipes(int? page)
        {
            const int pageSize = 25;
            var pageNumber = (page ?? 1);

            return View(_recipeService.ShowRecipes().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EditRecipe(EditeRecipeModel editRecipe)
        {
            if (_recipeService.EditRecipe(editRecipe))
            {
                return RedirectToAction("DetailsRecipe", "Recipe", new { Id = editRecipe.Id });
            }
            return null;
        }

        public ActionResult FindRecipes()
        {
            return View();
        }

        public ActionResult FindRecipesToList(string find)
        {
            return View(_recipeService.FindRecipes(find));
        }

        public ActionResult DetailsRecipe(int id)
        {
            if (_recipeService.DetailRecipe(id) == null)
            {
                return View("ShowRecipes");
            }
            var detRecipe = new DetailRecipe();
            detRecipe.UsersLikeRecipe = _recipeService.UsersLikeRecipe(id);
            detRecipe.Recipe = _recipeService.DetailRecipe(id);
            return View(detRecipe);
        }

        public ActionResult BestFiveRecipes()
        {
            return View(_recipeService.BestFiveRecipes());
        }

        public ActionResult SearchByCategory(string category, string categoryOfFOod)
        {
            return View(_recipeService.SearchByCategory(category, categoryOfFOod));
        }

        public ActionResult MenuShow()
        {
            return View(_recipeService.MenuShow());
        }
        public ActionResult RandomRecipe()
        {

            return RedirectToAction("DetailsRecipe", "Recipe", new { id = _recipeService.RandomRecipe() });
        }

        [HttpPost]
        public void LikeRecipe(int id)
        {
            _recipeService.AddLike(id);
        }

        [HttpPost]
        public void RemoveLikeRecipe(int id)
        {
            _recipeService.RemoveLike(id,UserHelper.UserName());
        }

        [HttpPost]
        [Route("Recipe/CheckRecipeTitleExist/{title}")]
        public string CheckRecipeTitleExist(string title)
        {
            return _recipeService.CheckRecipeTitleExist(title);
        }
    }

    //public ActionResult AdvancedSearch(List<string> component)
    //{
    //    if (component != null)
    //    {
    //        SortedDictionary<int, int> recipes = new SortedDictionary<int, int>();
    //        List<Recipe> recipesList = new List<Recipe>();



    //        foreach (var item in component)
    //        {

    //            var components = db.Components.Where(x => x.Name == item).Include(c => c.Recipes).ToList();
    //            foreach (var model in components)
    //            {
    //                int recipeId = model.Recipes.Select(x => x.Id).SingleOrDefault();
    //                if (recipes.ContainsKey(recipeId))
    //                {
    //                    recipes[recipeId]++;
    //                }
    //                else
    //                {
    //                    recipes.Add(recipeId, 1);

    //                }
    //            }
    //        }
    //        foreach (var recipeKey in recipes)
    //        {
    //            recipesList.Add(db.Recipes.FirstOrDefault(x => x.Id == recipeKey.Key));
    //        }

    //        return View("AdvancedSearchResoult", recipesList);
    //    }
    //    return View();
    //}

    //public ActionResult AdvancedSearch(List<string> components)
    //{
    //    if (components == null) return View();

    //    var response = new List<AdvanceSearchViewModel>();
    //    var result = new AdvanceSearchViewModel();

    //    for (var i = 0; i < components.Count(); i++)
    //    {
    //        var recipes = db.Recipes.AsQueryable();

    //        foreach (var component in components)
    //        {
    //            recipes = recipes.Where(r => r.Components.Any(c => c.Name == component));

    //            if (recipes.Count() > 0)
    //                result = new AdvanceSearchViewModel() { Recipes = recipes.ToList(), ComponentsMatched = i };
    //            else break;
    //        }

    //        response.Add(result);
    //    }

    //    return View("AdvancedSearchResoult", response.ToList());


    //}


}
