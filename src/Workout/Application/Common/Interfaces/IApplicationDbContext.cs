using Domain.WorkoutAggregate;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Workout> Workout { get; }

    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);
}