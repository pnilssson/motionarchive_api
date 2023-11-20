using Application.Common.Interfaces;
using Application.Features.WorkoutFeature.Common.Models;
using AutoMapper;
using Domain.WorkoutAggregate;
using MediatR;

namespace Application.Features.WorkoutFeature.Commands.CreateWorkout;

public class CreateWorkoutHandler : IRequestHandler<CreateWorkoutCommand, WorkoutResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateWorkoutHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<WorkoutResponse> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = new Workout(request.Description, DateOnly.FromDateTime(request.Date), request.Time, request.WorkoutTypeId);
        var result = _context.Workout.Add(workout);
        
        await _context.SaveEntitiesAsync(cancellationToken);

        return _mapper.Map<WorkoutResponse>(result.Entity);
    }
}