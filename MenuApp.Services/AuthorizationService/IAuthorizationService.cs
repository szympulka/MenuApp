using MenuApp.Core.Entities;
using MenuApp.Services.Models.UserModel;

namespace MenuApp.Services.AuthorizationService
{
    public interface IAuthorizationService
    {
        void Registration(User user);
        bool Login(LoginUserModel user);
    }
}
