using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuApp.Core.Entities
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Login is required")]
        [StringLength(20, ErrorMessage = "Max 20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [ScaffoldColumn(false)]
        public string Password { get; set; }
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Column(TypeName = "date")]
        [ScaffoldColumn(false)]
        public DateTime DateCreateAccount { get; set; }
        [Column(TypeName = "date")]
        [ScaffoldColumn(false)]
        public DateTime? DateOfChangePassword { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        [ScaffoldColumn(false)]
        public string VerificationToken {get;set;}

    }
}