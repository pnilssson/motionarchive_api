using Application.Features.WorkoutTypeFeature.Common.Models;
using MediatR;

namespace Application.Features.WorkoutTypeFeature.Queries.GetWorkoutTypes;

public class GetWorkoutTypesQuery : IRequest<List<WorkoutTypeResponse>>
{
    
}