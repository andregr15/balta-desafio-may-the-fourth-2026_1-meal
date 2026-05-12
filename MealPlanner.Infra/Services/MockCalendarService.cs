using MealPlanner.Core.Models;
using MealPlanner.Core.Services.Abstractions;

namespace MealPlanner.Infra.Services;

public class MockCalendarService : ICalendarService
{
    public async Task<Calendar> GetCalendarAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(2000, cancellationToken); // Simulate async work

        var Calendar = new Calendar
        {
            Days = new List<Day>
            {
                new() {
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Appointments =
                    [
                        new Appointment
                        {
                            Title = "Breakfast",
                            Description = "Have breakfast at 8 AM",
                            Time = new TimeOnly(8, 0),
                            Duration = new TimeOnly(0, 30)
                        },
                        new Appointment
                        {
                            Title = "Workout",
                            Description = "Workout at 9:30 AM",
                            Time = new TimeOnly(9, 30),
                            Duration = new TimeOnly(1, 30)
                        },
                        new Appointment
                        {
                            Title = "Lunch",
                            Description = "Have lunch at 12 PM",
                            Time = new TimeOnly(12, 0),
                            Duration = new TimeOnly(1, 0)
                        },
                        new Appointment
                        {
                            Title = "Study",
                            Description = "Study at 14 PM",
                            Time = new TimeOnly(14, 0),
                            Duration = new TimeOnly(1, 0)
                        },
                        new Appointment
                        {
                            Title = "Dinner",
                            Description = "Have dinner at 7 PM",
                            Time = new TimeOnly(19, 0),
                            Duration = new TimeOnly(1, 0)
                        }
                    ]
                }
            }
        };

        return await Task.FromResult(Calendar);
    }
}
