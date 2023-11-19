using Application.Features.WorkoutFeature.Common.Models;
using AutoMapper;
using Domain.WorkoutAggregate;

namespace Application.Features.WorkoutFeature.Common;

public class WorkoutMappingProfile : Profile
{
    public WorkoutMappingProfile()
    {
        CreateMap<Workout, WorkoutResponse>();
    }
}