using System.Web.Mvc;
using MenuApp.Services.Models.RecipeModel;
using MenuApp.Services.RecipeService;
using System.Web;
using MenuApp.Common.Helpers;
using MenuApp.Services.Models;
using PagedList;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            return View(_recipeService.DetailsRecipe(id));
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

        [HttpGet]
        [Route("Recipe/BestFourRecipes/{title}/{category}")]
        public ActionResult BestFourRecipes(string title,string category)
        {
            return this.Json(_recipeService.BestFourRecipes(title), JsonRequestBehavior.AllowGet);
        }
    }

}
