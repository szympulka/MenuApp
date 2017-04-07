using System;
using MenuApp.Core.Entities;
using MenuApp.Services.Models.UserModel;
using MenuApp.Common.Helpers;
using System.Web.Security;
using MenuApp.Services.Fakes.MailService;
using System.Linq;
#if !DEBUG
using MenuApp.Services.MailService;
#endif
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


        public bool Registration(RegistrationModel userModel)
        {
            var checkUser = _dataContext.All<User>().FirstOrDefault(x => x.UserName == userModel.UserName || x.Email == userModel.Email);
            if (checkUser != null) return false; 
            var date = new DateTimeHelper();
            var user = new User();
            user.Email = userModel.Email;
            user.UserName = userModel.UserName;
            user.Password = PassHelper.HashPassword(user.Password);
            user.DateCreateAccount = date.LocalDateTime();
            user.Role = "User";
            user.DateOfChangePassword = null;
            user.IsActive = false;
            user.VerificationToken = TokensHelper.GetTokenGuid();

            _mailService.SendMail_Sendgrid(user.Email, "Potwierdzenie Rejestracji",
                "Kliknij by potwierdzić! " + Common.Consts.Url_Registration + user.VerificationToken);

            _dataContext.Add<User>(user);
            _dataContext.SaveChanges();
            return true;
        }
        public void ActivateAccount(string token)
        {
            var user = _dataContext.All<User>().FirstOrDefault(x => x.VerificationToken == token);
            if (!user.IsActive) user.IsActive = true;
            _dataContext.SaveChanges();
        }

        public ChangePasswordModel ChangePasswordByLink(string key)
        {
            if (string.IsNullOrEmpty((key))) return null;

            ChangePasswordModel user = new ChangePasswordModel();
            var findUser = _dataContext.All<User>().FirstOrDefault(x => x.VerificationToken == key);
            if (findUser != null && findUser.IsActive)
            {
                user.UserId = findUser.Id;
                return user;
            }
            return null;
        }

        public bool ChangePasswordByLink(ChangePasswordModel passwordModel)
        {
            var date = new DateTimeHelper();
            var findUser = _dataContext.All<User>().FirstOrDefault(x => x.Id == passwordModel.UserId);
            if (findUser == null) return false;
            findUser.Password = PassHelper.HashPassword(passwordModel.NewPassword);
            findUser.VerificationToken = null;
            findUser.DateOfChangePassword = date.LocalDateTime();
            _dataContext.SaveChanges();
            return true;

        }
        public bool ChangePassword(ChangePasswordModel changeModel)
        {
            var date = new DateTimeHelper();
            var user = _dataContext.All<User>().FirstOrDefault(x => x.Id == changeModel.UserId);
            if (user == null || user.Password != PassHelper.HashPassword(changeModel.NewPassword)) return false;
            user.Password = PassHelper.HashPassword(changeModel.NewPassword);
            user.DateOfChangePassword = date.LocalDateTime();
            _dataContext.SaveChanges();
            return true;
        }
    }
}
