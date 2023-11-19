using Domain.WorkoutAggregate;
using Domain.WorkoutTypeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Workout> Workout { get; }
    
    DbSet<WorkoutType> WorkoutType { get; }

    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);
}