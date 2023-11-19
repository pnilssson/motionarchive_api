using Domain.SeedWork;

namespace Domain.WorkoutAggregate;

public class Workout : Entity, IAggregateRoot
{
    public string Description { get; private set; }

    public DateTime Date { get; private set; }
    
    public Workout(string description, DateTime date)
    {
        Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ArgumentNullException(nameof(description));
        Date = date;
    }
}