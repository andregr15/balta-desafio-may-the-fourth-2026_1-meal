using MealPlanner.Ai;
using MealPlanner.Core;
using MealPlanner.Core.Requests;
using MealPlanner.Core.Services.Abstractions;
using MealPlanner.Infra;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAgents();
builder.Services.AddInfrastructure();

var app = builder.Build();

Configuration.RootPath = app.Environment.ContentRootPath;
Configuration.OpenAiKey = builder.Configuration.GetValue<string>("OpenApiKey") ?? string.Empty;

app.MapGet("/", () => "Hello World!");

app.MapPost("/generate-meal", async (
    GenerateMealRequest request,
    IRecipeService recipeService
) => await recipeService.GenerateRecipiesAsync(request.Ingredients, cancellationToken: default));

app.Run();
