using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Features.WorkoutFeature.Commands.CreateWorkout;

public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
{
    public CreateWorkoutCommandValidator(IApplicationDbContext context)
    {
        RuleFor(command => command.Time)
            .GreaterThan(0);

        RuleFor(command => command.WorkoutTypeId)
            .Must(workoutTypeId => context.WorkoutType.Any(wt => wt.Id == workoutTypeId))
            .WithMessage("Workout type was not found.");
    }
}