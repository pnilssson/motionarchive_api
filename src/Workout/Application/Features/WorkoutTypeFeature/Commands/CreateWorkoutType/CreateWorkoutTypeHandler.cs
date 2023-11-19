using Application.Common.Interfaces;
using Application.Features.WorkoutFeature.Commands.CreateWorkout;
using Application.Features.WorkoutFeature.Common.Models;
using Application.Features.WorkoutTypeFeature.Common.Models;
using AutoMapper;
using Domain.WorkoutAggregate;
using Domain.WorkoutTypeAggregate;
using MediatR;

namespace Application.Features.WorkoutTypeFeature.Commands.CreateWorkoutType;

public class CreateWorkoutTypeHandler: IRequestHandler<CreateWorkoutTypeCommand, WorkoutTypeResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateWorkoutTypeHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<WorkoutTypeResponse> Handle(CreateWorkoutTypeCommand request, CancellationToken cancellationToken)
    {
        var workoutType = new WorkoutType(request.Name);
        var result = _context.WorkoutType.Add(workoutType);
        
        await _context.SaveEntitiesAsync(cancellationToken);

        return _mapper.Map<WorkoutTypeResponse>(result.Entity);
    }
}