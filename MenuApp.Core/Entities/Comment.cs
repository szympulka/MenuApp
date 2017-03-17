using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApp.Core.Entities;

namespace MenuWeb.Core.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int Likes { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime DateAdded { get; set; }
        public int IdRecipe { get; set; }

        [ForeignKey("IdRecipe")]
        public virtual Recipe Recipe { get; set; }
    }
}
