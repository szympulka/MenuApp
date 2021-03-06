﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MenuApp.Core.Entities;

namespace MenuWeb.Core.Entities
{
    public class RecipeComment
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
