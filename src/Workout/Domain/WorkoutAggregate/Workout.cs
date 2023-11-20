using Domain.SeedWork;
using Domain.WorkoutTypeAggregate;

namespace Domain.WorkoutAggregate;

public class Workout : Entity, IAggregateRoot
{
    public string Description { get; private set; }

    public DateOnly Date { get; private set; }
    
    public int Time { get; private set; }
    
    public int WorkoutTypeId { get; private set; }

    public WorkoutType WorkoutType { get; private set; } = null!;
    
    public Workout(string description, DateOnly date, int time, int workoutTypeId)
    {
        Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ArgumentNullException(nameof(description));
        Date = date;
        Time = time > 0 ? time : throw new ArgumentException($"Required input {nameof(time)} cannot be zero or negative.");
        WorkoutTypeId = workoutTypeId > 0 ? workoutTypeId : throw new ArgumentException($"Required input {nameof(workoutTypeId)} cannot be zero or negative.");;
    }
}