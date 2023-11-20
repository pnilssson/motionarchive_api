using Application.Features.WorkoutFeature.Common.Models;
using MediatR;

namespace Application.Features.WorkoutFeature.Commands.CreateWorkout;

public class CreateWorkoutCommand : IRequest<WorkoutResponse>
{
    public string Description { get; init; } = string.Empty;

    public DateTime Date { get; init; }
    
    public int Time { get; init; }

    public int WorkoutTypeId { get; init; }
}