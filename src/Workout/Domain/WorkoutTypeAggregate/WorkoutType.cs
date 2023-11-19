using Domain.SeedWork;
using Domain.WorkoutAggregate;

namespace Domain.WorkoutTypeAggregate;

public class WorkoutType : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    private readonly List<Workout> _workouts = new();
    
    public IReadOnlyCollection<Workout> Workouts => _workouts;
    
    public WorkoutType(string name)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
    }
}