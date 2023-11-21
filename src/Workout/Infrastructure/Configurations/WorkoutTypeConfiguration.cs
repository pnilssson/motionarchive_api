using Domain.WorkoutAggregate;
using Domain.WorkoutTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class WorkoutTypeConfiguration : IEntityTypeConfiguration<WorkoutType>
{
    public void Configure(EntityTypeBuilder<WorkoutType> builder)
    {
        builder.Ignore(wt => wt.DomainEvents);

        builder.Property(wt => wt.Name)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.HasMany<Workout>()
            .WithOne();
    }
}