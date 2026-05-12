using MealPlanner.Core.Models;

namespace MealPlanner.Core.Requests;

public class GenerateMealRequest
{
    public IEnumerable<Ingredient> Ingredients { get; set; } = [];
}
