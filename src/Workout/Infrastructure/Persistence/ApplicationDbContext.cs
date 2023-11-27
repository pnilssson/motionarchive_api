using Application.Common.Interfaces;
using Domain.SeedWork;
using Domain.WorkoutAggregate;
using Domain.WorkoutTypeAggregate;
using Infrastructure.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Workout> Workout { get; set; }
    
    public DbSet<WorkoutType> WorkoutType { get; set; }
    
    private readonly IMediator _mediator;
    private readonly ICurrentUser _currentUser;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator, ICurrentUser currentUser) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutTypeConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch Domain Events
        await _mediator.DispatchDomainEventsAsync(this);
        
        SetUserIdField();
        SetAuditorFields();

        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    private void SetUserIdField()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is UserOwnedAuditableEntity 
                        && e.State is EntityState.Added);
        
        foreach (var entityEntry in entries)
        {
            ((UserOwnedAuditableEntity)entityEntry.Entity).SetUserId(_currentUser.UserId);
        }
    }

    private void SetAuditorFields()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditableEntity 
                && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            ((AuditableEntity)entityEntry.Entity).SetUpdated(_currentUser.Username);

            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEntity)entityEntry.Entity).SetCreated(_currentUser.Username);
            }
        }
    }
}