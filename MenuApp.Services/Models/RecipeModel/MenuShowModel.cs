using System;
using System.Collections.Generic;

namespace MenuApp.Services.Models.RecipeModel
{
    public class MenuShowModel 
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string CategoryOfFood { get; set; }
        public List<String> CategoryEnumerable { get; set; }

    }
}