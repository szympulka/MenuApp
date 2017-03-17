using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Services.Models
{
    public class AddRecipeModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }
        public string CategoryOfFood { get; set; }
        public int? PreparationTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }
        public string Author { get; set; }
        public bool IsActive { get; set; }
        public string HardLevel { get; set; }
    }
}
