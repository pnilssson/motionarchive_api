namespace Application.Features.WorkoutFeature.Common.Models;

public class WorkoutResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}