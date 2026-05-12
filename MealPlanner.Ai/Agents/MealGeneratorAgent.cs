using MealPlanner.Ai.Models;
using MealPlanner.Ai.Providers.Abstractions;
using MealPlanner.Core;
using MealPlanner.Core.Agentes.Abstractions;
using MealPlanner.Core.Enums;
using MealPlanner.Core.Models;
using MealPlanner.Core.Services.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenAI;
using OpenAI.Chat;
using System.Text.Json;

namespace MealPlanner.Ai.Agents;

public class MealGeneratorAgent(
    IPromptProvider promptProvider,
    ILogger<MealGeneratorAgent> logger,
    [FromKeyedServices(CalendarServiceType.Mock)] ICalendarService calendarService
) : IAgent<IEnumerable<Ingredient>, IEnumerable<Recipe>>
{
    private const float Temperature = 0.7f;

    private const string Prompt = "Gere a receita com base nesse json: ";

    public async Task<IEnumerable<Recipe>> ExecuteAsync(
        IEnumerable<Ingredient> data,
        CancellationToken cancellationToken = default
    )
    {
        logger.LogInformation("Generating meals for the day with {IngredientCount} ingredients", data.Count());

        var client = new OpenAIClient(Configuration.OpenAiKey);

        var systemPrompt = await promptProvider.GetPromptAsync(
            nameof(MealGeneratorAgent),
            cancellationToken = default
        );

        var agent = client
            .GetChatClient(AiModels.Gpt4OMini)
            .AsAIAgent(new ChatClientAgentOptions()
            {
                Name = nameof(MealGeneratorAgent),
                Description = "Agente especialista em gerar receitas para o dia com base nos ingredientes disponíveis e na agenda do usuário.",
                ChatOptions = new ChatOptions()
                {
                    ModelId = AiModels.Gpt4OMini,
                    Temperature = Temperature,
                    Instructions = systemPrompt
                },
            });

        var prompt = $"{Prompt} {JsonSerializer.Serialize(data)} ";
        prompt += "Calendario do usuário: " + JsonSerializer.Serialize(
            await calendarService.GetCalendarAsync(cancellationToken)
        );

        var response = await agent.RunAsync<IEnumerable<Recipe>>(prompt, cancellationToken: cancellationToken);

        logger.LogInformation("Generated {RecipeCount} recipes for the day", response.Result.Count());

        return response.Result;
    }
}
