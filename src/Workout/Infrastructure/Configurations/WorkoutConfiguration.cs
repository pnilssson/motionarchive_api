using Domain.WorkoutAggregate;
using Domain.WorkoutTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.Ignore(w => w.DomainEvents);

        builder.Property(w => w.Description)
            .HasMaxLength(5000);
        
        builder.HasOne<WorkoutType>()
            .WithMany()
            .HasForeignKey("WorkoutTypeId");
    }
}