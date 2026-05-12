using MealPlanner.Ai.Agents;
using MealPlanner.Ai.Providers;
using MealPlanner.Ai.Providers.Abstractions;
using MealPlanner.Core.Agentes.Abstractions;
using MealPlanner.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MealPlanner.Ai;

public static class DependencyInjection
{
    public static IServiceCollection AddAgents(this IServiceCollection services)
    {
        services.AddTransient<IAgent<IEnumerable<Ingredient>, IEnumerable<Recipe>>, MealGeneratorAgent>();
        services.AddTransient<IPromptProvider, FilePromptProvider>();

        return services;
    }
}
