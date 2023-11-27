using Application.Features.WorkoutFeature.Commands.CreateWorkout;
using Application.Features.WorkoutFeature.Common.Models;
using Application.Features.WorkoutTypeFeature.Commands.CreateWorkoutType;
using Application.Features.WorkoutTypeFeature.Common.Models;
using Application.Features.WorkoutTypeFeature.Queries.GetWorkoutTypes;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Endpoints;

public static class WorkoutTypeEndpoint
{
    public static RouteGroupBuilder MapWorkoutTypes(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetWorkoutTypes)
            .RequireAuthorization();
        
        group.MapPost("/", CreateWorkoutType)
            .RequireAuthorization();;
            
        group.WithTags("WorkoutType")
            .WithOpenApi();

        return group;
    }
    
    private static async Task<Ok<List<WorkoutTypeResponse>>> GetWorkoutTypes(IMediator mediator)
    {
        var result = await mediator.Send(new GetWorkoutTypesQuery());
        return TypedResults.Ok(result);
    }

    private static async Task<Created<WorkoutTypeResponse>> CreateWorkoutType(IMediator mediator, CreateWorkoutTypeCommand command)
    {
        var result = await mediator.Send(command);
        return TypedResults.Created(result.Id.ToString(), result);
    }
}