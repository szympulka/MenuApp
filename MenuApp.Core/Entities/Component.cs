﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuApp.Core.Entities
{
    public class Component
    {
        public Component()
        {
            this.Recipes = new HashSet<Recipe>();
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        //////////////////////////////////////////////////////////////////////////////////////////
    }
}
