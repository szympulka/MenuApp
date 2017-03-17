using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuWeb.Core.Entities
{
    public class RecipeLike
    {
        [Key]
        [Column(Order = 1)]
        public int IdRecipe { get; set; }
        [Key]
        [Column(Order = 2)]
        public string UserName { get; set; }
    }
}
