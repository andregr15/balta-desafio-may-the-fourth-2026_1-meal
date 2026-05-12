using MealPlanner.Core.Models;

namespace MealPlanner.Core.Services.Abstractions;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GenerateRecipiesAsync(
        IEnumerable<Ingredient> ingredients,
        CancellationToken cancellationToken = default
    );
}
