namespace MealPlanner.Core.Models;

public class Recipe
{
    public string Name { get; set; } = string.Empty;
    public int PreparationTime { get; set; }
    public List<Ingredient> Ingredients { get; set; } = [];
}
