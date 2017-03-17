using System.Web.Mvc;
using MenuApp.Services.UserService;
using MenuApp.Services.Models.UserModel;
using MenuApp.Services.RecipeService;
using MenuApp.Services.QuestionService;
using PagedList;

namespace MenuApp.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IUserService _userService;
        private IRecipeService _recipeService;
        private IQuestionService _questionService;
        public AdminController(IUserService userService, IRecipeService recipeService,IQuestionService questionService)
        {
            _questionService = questionService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

        public ActionResult ShowUsers(int? page)
        {
            const int pageSize = 25;
            var pageNumber = (page ?? 1);          
            return View(_userService.ShowUsers().ToPagedList(pageNumber,pageSize));
        }

        public ActionResult EditUsers(EditUserModel editUser)
        {
            _userService.EditUser(editUser);
            return View("AdminPanel");          
        }

        public ActionResult InfoUser(int id)
        {
            return View(_userService.FindUser(id));
        }

        public ActionResult SubstitutionActiveUser(int id)
        {
            _userService.SubstitutionActive(id);
            return RedirectToAction("AdminPanel");
        }

        public ActionResult DeleteUser(int id)
        {
            _userService.RemoveUser(id);
            return RedirectToAction("ShowUsers");
        }

        // do poprawy partial view 
        public ActionResult FindUsers()
        {
            return View();
        }

        public ActionResult FindUsersToList(string find)
        {
            return View(_userService.FindUsers(find)); 
        }

        public ActionResult ShowActiveQuestions()
        {         
            return View(_questionService.ShowActiveQuestions());
        } // dopracuj odpowiedz przez wysyłkę maila 

        public ActionResult ShowQuestions()
        {
            return View(_questionService.ShowQuestions());
        }

        public ActionResult AnswerTheQuestion(int id)
        {
            return View(_questionService.AnswerTheQuestion(id));
        }

        public ActionResult ChangeActivityQuestion(int id)
        {
            _questionService.ChangeActivityQuestion(id);
            return RedirectToAction("AdminPanel");
        }

        public ActionResult DeleteRecipe(int id)
        {
            _recipeService.RemoveRecipe(id);
            return RedirectToAction("AdminPanel", "Admin");
        }

        public ActionResult NewRecipes()
        {
            return View(_recipeService.NewRecipes());
        }

        public ActionResult NewUsers()
        {
            return View(_userService.NewUsers());
        }

        [HttpGet]
        public JsonResult ShowDetailsQuestion(int id)
        {
            return Json(_questionService.ShowDetailsQuestion(id), JsonRequestBehavior.AllowGet);
        }

    }
}