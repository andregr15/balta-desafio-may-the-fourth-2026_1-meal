
using MealPlanner.Core.Models;

namespace MealPlanner.Core.Services.Abstractions;

public interface ICalendarService
{
    Task<Calendar> GetCalendarAsync(
        CancellationToken cancellationToken = default
    );
}
