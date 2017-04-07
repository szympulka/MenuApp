using MenuApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuWeb.Core.Entities
{
    public class RecipePhotoLink
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public virtual Recipe Recipes { get; set; }
    }
}
