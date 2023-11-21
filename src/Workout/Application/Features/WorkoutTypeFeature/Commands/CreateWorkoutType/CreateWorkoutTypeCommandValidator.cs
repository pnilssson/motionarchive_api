using FluentValidation;

namespace Application.Features.WorkoutTypeFeature.Commands.CreateWorkoutType;

public class CreateWorkoutTypeCommandValidator : AbstractValidator<CreateWorkoutTypeCommand>
{
    public CreateWorkoutTypeCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}