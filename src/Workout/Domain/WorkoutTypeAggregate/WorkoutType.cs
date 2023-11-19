using Domain.SeedWork;

namespace Domain.WorkoutTypeAggregate;

public class WorkoutType : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    
    public WorkoutType(string name)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
    }
}