using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Services.Models.RecipeModel
{
    public class FindRecipesByAjaxModel
    {
        public string Title { get; set; }
        public string HardLevel { get; set; }
        public string ShortDescription { get; set; }
        public string Author { get; set; }
    }
}
