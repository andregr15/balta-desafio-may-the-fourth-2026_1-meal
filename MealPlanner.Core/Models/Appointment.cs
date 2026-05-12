namespace MealPlanner.Core.Models;

public class Appointment
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TimeOnly Time { get; set; }

    public TimeOnly Duration { get; set; }
}
