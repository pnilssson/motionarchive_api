using Domain.WorkoutAggregate;
using FluentAssertions;

namespace Application.UnitTests;

public class WorkoutAggregateTests
{
    [Fact]
    public void Creating_Workout_With_Valid_Values_Should_Not_Throw_Exception()
    {
        // Arrange
        const string description = "Rowing";
        var date = DateOnly.FromDateTime(DateTime.Now);
        const int time = 15;
        const int workoutTypeId = 1;

        // Act
        var workout = new Workout(description, date, time, workoutTypeId);

        // Assert
        workout.Description.Should().Be(description);
        workout.Date.Should().Be(date);
        workout.Time.Should().Be(time);
        workout.WorkoutTypeId.Should().Be(workoutTypeId);
        workout.DomainEvents.Should().BeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Creating_Workout_With_Invalid_Description_Should_Throw_Exception(string description)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Now);
        const int time = 15;
        const int workoutTypeId = 1;
        
        // Act
        Action action = () => new Workout(description, date, time, workoutTypeId);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Creating_Workout_With_Invalid_Time_Should_Throw_Exception(int time)
    {
        // Arrange
        const string description = "Rowing";
        var date = DateOnly.FromDateTime(DateTime.Now);
        const int workoutTypeId = 1;
        
        // Act
        Action action = () => new Workout(description, date, time, workoutTypeId);

        // Assert
        action.Should().ThrowExactly<ArgumentException>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Creating_Workout_With_Invalid_WorkoutTypeId_Should_Throw_Exception(int workoutTypeId)
    {
        // Arrange
        const string description = "Rowing";
        var date = DateOnly.FromDateTime(DateTime.Now);
        const int time = 15;
        
        // Act
        Action action = () => new Workout(description, date, time, workoutTypeId);

        // Assert
        action.Should().ThrowExactly<ArgumentException>();
    }
}