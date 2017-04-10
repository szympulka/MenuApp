using System.Web.Mvc;
using System.Web.Security;
using MenuApp.Services.UserService;
using MenuApp.Services.Models.UserModel;
using MenuApp.Services.AuthorizationService;

namespace MenuApp.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private IUserService _userService;
        private IAuthorizationService _authorizationService;
        public AuthorizationController(IUserService userService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }

        // GET: Authorization
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            if (model.Password != null)
            {
                if (_authorizationService.Registration(model))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {        
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserModel model)
        {
            if (model.UserName != null && model.Password != null)
            {
                if (_authorizationService.Login(model)) return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult ChangePasswordByLink(ChangePasswordModel passModel)
        {
            if (HttpContext.User.Identity.IsAuthenticated || string.IsNullOrEmpty(passModel.NewPassword))
                return View("ChangePasswordByLink", passModel);
            _authorizationService.ChangePasswordByLink(passModel);
            return RedirectToAction("Index", "Home");
        }

        [Route("Authorization/ActivateAccount/{key}")]
        public ActionResult ActivateAccount(string key)
        {
            _authorizationService.ActivateAccount(key);
            return RedirectToAction("Index", "Home");
        }
        [Route("Authorization/ChangePassword/{key}")]
        public ActionResult ChangePasswordByLink(string key)
        {
            return ChangePasswordByLink(_authorizationService.ChangePasswordByLink(key));
            
        }
        public ActionResult ChangePassword(ChangePasswordModel passwordModel)
        {
            if (passwordModel != null)
            {
                _authorizationService.ChangePasswordByLink(passwordModel);
            }
            return View(passwordModel);
        }
    }
}