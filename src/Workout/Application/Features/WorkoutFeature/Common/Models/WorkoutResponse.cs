namespace Application.Features.WorkoutFeature.Common.Models;

public class WorkoutResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public int Time { get; set; }
    public int WorkoutTypeId { get; set; }
}