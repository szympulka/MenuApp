namespace MenuApp.Services.Models.RecipeModel
{
    public class EditeRecipeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Category { get; set; }
        public int? PreparationTime { get; set; }
        public string CategoryOfFood { get; set; }
    }
}