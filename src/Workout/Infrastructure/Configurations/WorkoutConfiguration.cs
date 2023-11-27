using Domain.WorkoutAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.Ignore(w => w.DomainEvents);

        builder.HasIndex(w => w.UserId);

        builder.Property(w => w.Description)
            .HasMaxLength(4000);
    }
}