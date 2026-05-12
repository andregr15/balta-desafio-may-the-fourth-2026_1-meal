using MealPlanner.Core.Enums;
using MealPlanner.Core.Services.Abstractions;
using MealPlanner.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MealPlanner.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddKeyedTransient<ICalendarService, MockCalendarService>(CalendarServiceType.Mock);
        services.AddTransient<IRecipeService, RecipeService>();

        return services;
    }
}
