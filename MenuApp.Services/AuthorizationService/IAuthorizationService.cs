using MenuApp.Core.Entities;
using MenuApp.Services.Models.UserModel;

namespace MenuApp.Services.AuthorizationService
{
    public interface IAuthorizationService
    {
        bool Registration(RegistrationModel user);
        bool Login(LoginUserModel user);
        void ActivateAccount(string token);
        ChangePasswordModel ChangePasswordByLink(string key);
        bool ChangePasswordByLink(ChangePasswordModel passwordModel);
        bool ChangePassword(ChangePasswordModel changeModel);
    }
}
