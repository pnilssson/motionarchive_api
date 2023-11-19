using Application.Features.WorkoutTypeFeature.Common.Models;
using AutoMapper;
using Domain.WorkoutTypeAggregate;

namespace Application.Features.WorkoutTypeFeature.Common;

public class WorkoutTypeMappingProfile : Profile
{
    public WorkoutTypeMappingProfile()
    {
        CreateMap<WorkoutType, WorkoutTypeResponse>();
    }
}