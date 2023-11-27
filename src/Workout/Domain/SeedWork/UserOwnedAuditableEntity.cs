namespace Domain.SeedWork;

public abstract class UserOwnedAuditableEntity : AuditableEntity
{
    public string UserId { get; protected set; } = string.Empty;

    public void SetUserId(string userId)
    {
        UserId = userId;
    }
}