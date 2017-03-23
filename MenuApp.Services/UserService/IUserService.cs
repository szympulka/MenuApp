using MenuApp.Core.Entities;
using MenuApp.Services.Models.UserModel;
using System.Collections.Generic;

namespace MenuApp.Services.UserService
{
    public interface IUserService
    {
        void RemoveUser(int id);
        List<User> FindUsers(string user);
        User FindUser(int id);
        bool ValidateUser(LoginUserModel userModel);
        string UserRole(string userName);
        bool IsAdmin(string userName);
        List<User> ShowUsers();
        void SubstitutionActive(int id);
        List<Recipe> UserRecipes();
        User EditUser(EditUserModel editUser);
        List<User> NewUsers();
        void ActivateAccount(string token);
        ChangePasswordModel ChangePasswordByLink(string key);
        bool ChangePasswordByLink(ChangePasswordModel passwordModel);
        bool ChangePassword(ChangePasswordModel changeModel);

    }
}