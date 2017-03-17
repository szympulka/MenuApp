using System;

namespace MenuApp.Services.Models.UserModel
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; }
        public string CurretnPassword { get; set; }
        public string NewPassword { get; set; }
        public DateTime DateOfChange { get; set; }
    }
}