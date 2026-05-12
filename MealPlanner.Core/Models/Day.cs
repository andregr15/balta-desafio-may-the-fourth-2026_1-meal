namespace MealPlanner.Core.Models;

public class Day
{
    public DateOnly Date { get; set; }

    public List<Appointment> Appointments { get; set; } = [];
}
