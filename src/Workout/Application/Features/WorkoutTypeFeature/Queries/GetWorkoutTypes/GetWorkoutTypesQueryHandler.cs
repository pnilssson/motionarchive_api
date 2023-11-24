using Application.Common.Interfaces;
using Application.Features.WorkoutTypeFeature.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WorkoutTypeFeature.Queries.GetWorkoutTypes;

public class GetWorkoutTypesQueryHandler : IRequestHandler<GetWorkoutTypesQuery, List<WorkoutTypeResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkoutTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkoutTypeResponse>> Handle(GetWorkoutTypesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.WorkoutType.ToListAsync(cancellationToken);

        return _mapper.Map<List<WorkoutTypeResponse>>(result);
    }
}