using Domain.WorkoutTypeAggregate;
using FluentAssertions;

namespace Application.UnitTests.Aggregates;

public class WorkoutTypeAggregateTests
{
    [Fact]
    public void Creating_Workout_Type_With_Valid_Values_Should_Create_Workout_Type()
    {
        // Arrange
        const string name = "Rowing";

        // Act
        var workoutType = new WorkoutType(name);

        // Assert
        workoutType.Should().NotBeNull();
        workoutType.Name.Should().Be(name);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Creating_Workout_Type_With_Invalid_Name_Should_Throw_Exception(string name)
    {
        // Arrange
        
        // Act
        Action action = () => new WorkoutType(name);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }
}