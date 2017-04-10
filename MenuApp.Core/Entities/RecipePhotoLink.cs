using MenuApp.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
