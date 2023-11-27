using Domain.SeedWork;

namespace Domain.WorkoutAggregate;

public class Workout : UserOwnedAuditableEntity, IAggregateRoot
{
    public string Description { get; private set; }

    public DateOnly Date { get; private set; }
    
    public int Time { get; private set; }
    
    public int WorkoutTypeId { get; private set; }
    
    public Workout(string description, DateOnly date, int time, int workoutTypeId)
    {
        Description = description;
        Date = date;
        Time = time;
        WorkoutTypeId = workoutTypeId;
    }
}