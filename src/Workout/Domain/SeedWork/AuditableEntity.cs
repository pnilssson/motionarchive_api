namespace Domain.SeedWork;

public abstract class AuditableEntity : Entity
{
    public string CreatedBy { get; protected set; } = string.Empty;
    
    public DateTime Created { get; protected set; }

    public string UpdatedBy { get; protected set; } = string.Empty;
    
    public DateTime Updated { get; protected set; }

    public void SetCreated(string username)
    {
        CreatedBy = username;
        Created = DateTime.Now;
    }

    public void SetUpdated(string username)
    {
        UpdatedBy = username;
        Updated = DateTime.Now;
    }
}