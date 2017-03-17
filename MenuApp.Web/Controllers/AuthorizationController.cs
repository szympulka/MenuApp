using System.Web.Mvc;
using System.Web.Security;
using MenuApp.Core.Entities;
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
        public ActionResult Registration(User model)
        {
            if (ModelState.IsValid && model.Password != null)
            {
                _authorizationService.Registration(model);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Login(LoginUserModel model)
        {
           
            if (model.UserName != null && model.Password != null)
            {
                if (_authorizationService.Login(model)) return RedirectToAction("Index", "Home");
                // zły login lub hasło paatrialview dodaj
            }
            return View();
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
            _userService.ChangePasswordByLink(passModel);
            return RedirectToAction("Index", "Home");
        }

        [Route("Authorization/ActivateAccount/{key}")]
        public ActionResult ActivateAccount(string key)
        {
            _userService.ActivateAccount(key);
            return RedirectToAction("Index", "Home");
        }
        [Route("Authorization/ChangePassword/{key}")]
        public ActionResult ChangePasswordByLink(string key)
        {
            return ChangePasswordByLink(_userService.ChangePasswordByLink(key));
            
        }
        public ActionResult ChangePassword(ChangePasswordModel passwordModel)
        {
            if (passwordModel != null)
            {
                _userService.ChangePasswordByLink(passwordModel);
            }
            return View(passwordModel);
        }
    }
}