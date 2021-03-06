﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MenuWeb.Core.Entities;

namespace MenuApp.Core.Entities
{
    [Table("Recipes")]
    public class Recipe
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public Recipe()
        {
            this.RecipeComponents = new HashSet<RecipeComponent>();
        }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Max 20 characters")]
        public string Title { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int? PreparationTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }
        public int RecipeLikes { get; set; }
        public int RecipeDisLikes { get; set; }
        public string Author { get; set; }
        public bool IsActive { get; set; }
        public string HardLevel { get; set; }
        public int Views { get; set; }
        public int CategoryId { get; set; }

        
        public virtual ICollection<RecipePhotoLink> RecipePhotoLinks { get; set; }
        public virtual ICollection<RecipeComponent> RecipeComponents { get; set; }
        public virtual ICollection<RecipeComment> RecipeComments { get; set; }

        [ForeignKey("CategoryId")]
        public virtual RecipeCategory RecipeCategories { get; set; }
    }
}