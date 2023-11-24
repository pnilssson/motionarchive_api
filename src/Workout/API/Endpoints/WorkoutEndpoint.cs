using Application.Features.WorkoutFeature.Commands.CreateWorkout;
using Application.Features.WorkoutFeature.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Endpoints;

public static class WorkoutEndpoint
{
    public static RouteGroupBuilder MapWorkouts(this RouteGroupBuilder group)
    {
        group.MapPost("/", CreateWorkout);
        
        group.WithTags("Workout")
            .WithOpenApi();

        return group;
    }

    private static async Task<Created<WorkoutResponse>> CreateWorkout(IMediator mediator, CreateWorkoutCommand command)
    {
        var result = await mediator.Send(command);
        return TypedResults.Created(result.Id.ToString(), result);
    }
}