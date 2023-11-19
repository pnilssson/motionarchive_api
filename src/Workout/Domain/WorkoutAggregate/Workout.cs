using Domain.SeedWork;
using Domain.WorkoutTypeAggregate;

namespace Domain.WorkoutAggregate;

public class Workout : Entity, IAggregateRoot
{
    public string Description { get; private set; }

    public DateOnly Date { get; private set; }
    
    public int WorkoutTypeId { get; private set; }

    public WorkoutType WorkoutType { get; private set; } = null!;
    
    public Workout(string description, DateOnly date, int workoutTypeId)
    {
        Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ArgumentNullException(nameof(description));
        Date = date;
        WorkoutTypeId = workoutTypeId;
    }
}