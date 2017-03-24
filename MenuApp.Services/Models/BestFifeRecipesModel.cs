using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Services.Models
{
    public class BestFifeRecipesModel
    {
        public string Title { get; set; }
        public int RecipeLikes { get; set; }
        public int RecipeDisLikes { get; set; }
        public int CountComments { get; set; }
        public DateTime DateAdded { get; set; }
        public string ShortDescription { get; set; }
    }
}
