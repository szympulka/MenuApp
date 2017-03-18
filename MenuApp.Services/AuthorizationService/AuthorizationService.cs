using System;
using MenuApp.Core.Entities;
using MenuApp.Services.Models.UserModel;
using MenuApp.Common.Helpers;
using System.Web.Security;
using MenuApp.Services.Fakes.MailService;
using MenuApp.Services.UserService;

namespace MenuApp.Services.AuthorizationService
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
#if DEBUG
        private IUserService _userService;
        private IMailServiceFake _mailService;
        public AuthorizationService(IDataContext dataContext, IUserService userService, IMailServiceFake mailService) : base(dataContext)
        {
            _mailService = mailService;
            _userService = userService;
        }
#else
        private IUserService _userService;
        private IMailService _mailService;
        public AuthorizationService(IDataContext dataContext, IUserService userService, IMailService mailService) : base(dataContext)
        {
            _mailService = mailService;
            _userService = userService;
        }
#endif




        public bool Login(LoginUserModel user)
        {
            if (_userService.ValidateUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return true;
            }
            return false;
        }


        public void Registration(User user)
        {
            var date = new DateTimeHelper();
            user.Password = PassHelper.HashPassword(user.Password);
            user.DateCreateAccount = date.LocalDateTime();
            user.Role = "User";
            user.DateOfChangePassword = null;
            user.IsActive = false;
            user.VerificationToken = Guid.NewGuid().ToString();
            _mailService.SendMail_Sendgrid(user.Email, "Potwierdzenie Rejestracji",
                "Kliknij by potwierdzić! " + Common.Consts.Url_Registration + user.VerificationToken);
            _dataContext.Add<User>(user);
            _dataContext.SaveChanges();
        }
    }
}
