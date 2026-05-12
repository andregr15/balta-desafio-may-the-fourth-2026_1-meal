using MealPlanner.Core.Agentes.Abstractions;
using MealPlanner.Core.Models;
using MealPlanner.Core.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace MealPlanner.Infra.Services;

public class RecipeService(
    ILogger<RecipeService> logger,
    IAgent<IEnumerable<Ingredient>, IEnumerable<Recipe>> agent
) : IRecipeService
{
    public async Task<IEnumerable<Recipe>> GenerateRecipiesAsync(
        IEnumerable<Ingredient> ingredients,
        CancellationToken cancellationToken = default
    )
    {
        logger.LogInformation("Generating recipes for {IngredientCount} ingredients", ingredients.Count());

        var recipes = await agent.ExecuteAsync(ingredients, cancellationToken);

        logger.LogInformation("Generated {RecipeCount} recipes", recipes.Count());

        return recipes;
    }
}
