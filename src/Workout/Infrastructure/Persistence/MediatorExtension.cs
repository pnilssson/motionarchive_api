using Domain.SeedWork;
using MediatR;

namespace Infrastructure.Persistence;

static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, ApplicationDbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents is { Count: > 0 })
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents ?? new List<INotification>())
            .ToList();

        domainEntities
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
