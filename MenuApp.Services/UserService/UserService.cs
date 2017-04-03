using MenuApp.Core.Entities;
using MenuApp.Services.Models.UserModel;
using System.Linq;
using MenuApp.Common.Helpers;
using System.Collections.Generic;
using System.Data.Entity;

namespace MenuApp.Services.UserService

{
    public class UserService : BaseService, IUserService
    {

        public UserService(IDataContext context)
            : base(context)
        {

        }

        public void RemoveUser(int id)
        {
            var model = _dataContext.Find<User>(id);
            _dataContext.Remove<User>(model);
            _dataContext.SaveChanges();
        }
        public List<User> FindUsers(string findUsers)
        {
            if (findUsers == "aktywni" || findUsers == "aktywni uzytkownicy" || findUsers == "true" ||
             findUsers == "aktywni użytkownicy")
            {
                var active = _dataContext.All<User>().Where(x => x.IsActive);
                return active.ToList();
            }
            if (findUsers == "nieaktywni" || findUsers == "nieaktywni użytkownicy" || findUsers == "false" ||
                findUsers == "nieaktywni uzytkownicy")
            {
                var active = _dataContext.All<User>().Where(x => x.IsActive == false);
                return active.ToList();
            }
            var users = _dataContext.All<User>().AsQueryable();
            users =
               _dataContext.All<User>().Where(
                    u => u.Email == findUsers || u.Role == findUsers || u.UserName == findUsers);
            return users.ToList();
        }
        public User FindUser(int id)
        {
            return _dataContext.Find<User>(id);
        }
        public bool ValidateUser(LoginUserModel userModel)
        {
            var user = _dataContext.All<User>().FirstOrDefault(u => u.UserName == userModel.UserName);

            if (user != null && userModel.UserName == user.UserName && PassHelper.HashPassword(userModel.Password) == user.Password)
            {
                return true;
            }
            return false;
        }
        public string UserRole(string userName)
        {
            var user = _dataContext.All<User>().First(u => u.UserName == userName);
            if (user != null)
            {
                return user.Role;
            }
            return null;
        }
        public bool IsAdmin(string userName)
        {
            if (UserRole(userName) == "Administartor") return true;
            return false;
        }
        public List<User> ShowUsers()
        {
           return _dataContext.All<User>().AsNoTracking().ToList();         
        }
        public void SubstitutionActive(int id)
        {
            var user = _dataContext.Find<User>(id);
            if (user.IsActive)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
        }
        public User EditUser(EditUserModel editUser)
        {
            if (FindUser(editUser.Id) != null)
            {
                var user = _dataContext.All<User>().First(x => x.Id == editUser.Id);
                user.IsActive = editUser.IsActive;
                user.Role = editUser.Role;
                _dataContext.SaveChanges();
                return user;
            }
            return null;
        }
        public List<User> NewUsers()
        {
            var count = _dataContext.All<User>().Count();
            if (count < 5) return null;
            return _dataContext.All<User>().OrderBy(x => x.Id).Skip(count - 5).Take(5).ToList();
        }
        public List<Recipe> UserRecipes()
        {
            return _dataContext.All<Recipe>().Where(x => x.Author == UserHelper.UserName()).ToList();
        }
    }
}
