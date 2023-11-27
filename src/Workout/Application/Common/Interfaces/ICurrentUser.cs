namespace Application.Common.Interfaces;

public interface ICurrentUser
{
    public string Username { get; }
    public string UserId { get; }
}