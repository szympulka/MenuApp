using System.Web.Mvc;
using MenuApp.Services.UserService;

namespace MenuApp.Web.Controllers
{
    public class UserController : Controller
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult UserPanel()
        {
            return View();
        }

        public ActionResult UserRecipes()
        {
            return View(_userService.UserRecipes());
        }

        //change password
        // change mail 

    }
}