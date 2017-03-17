using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuApp.Core.Entities
{
    public class Contact
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        [Required(ErrorMessage = "Where is email?")]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateQuestion { get; set; }

        [Required(ErrorMessage = "Where is the question?")]
        public string Question { get; set; }

        public bool IsActive { get; set; }
    }
}