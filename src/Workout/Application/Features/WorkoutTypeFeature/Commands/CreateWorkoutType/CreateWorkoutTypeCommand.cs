using Application.Features.WorkoutTypeFeature.Common.Models;
using MediatR;

namespace Application.Features.WorkoutTypeFeature.Commands.CreateWorkoutType;

public class CreateWorkoutTypeCommand: IRequest<WorkoutTypeResponse>
{
    public string Name { get; init; } = string.Empty;
}