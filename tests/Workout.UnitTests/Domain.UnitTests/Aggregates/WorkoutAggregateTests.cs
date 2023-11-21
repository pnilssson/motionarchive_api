using Domain.WorkoutAggregate;
using FluentAssertions;

namespace Application.UnitTests.Aggregates;

public class WorkoutAggregateTests
{
    [Fact]
    public void Creating_Workout_With_Valid_Values_Should_Create_Workout()
    {
        // Arrange
        const string description = "Rowing";
        var date = DateOnly.FromDateTime(DateTime.Now);
        const int time = 15;
        const int workoutTypeId = 1;

        // Act
        var workout = new Workout(description, date, time, workoutTypeId);

        // Assert
        workout.Should().NotBeNull();
        workout.Description.Should().Be(description);
        workout.Date.Should().Be(date);
        workout.Time.Should().Be(time);
        workout.WorkoutTypeId.Should().Be(workoutTypeId);
        workout.DomainEvents.Should().BeNull();
    }
}