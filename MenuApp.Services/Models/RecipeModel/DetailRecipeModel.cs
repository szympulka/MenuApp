using MenuApp.Core.Entities;
using MenuWeb.Core.Entities;
using System;
using System.Collections.Generic;

namespace MenuApp.Services.Models.RecipeModel
{
    public class DetailRecipeModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? PreparationTime { get; set; }
        public DateTime DateAdded { get; set; }
        public int RecipeLikes { get; set; }
        public int RecipeDisLikes { get; set; }
        public string Author { get; set; }
        public string HardLevel { get; set; }
        public int Views { get; set; }
        public Comment Comments { get; set; }
        public List<string> RecipeComponents { get; set; }



    }
}