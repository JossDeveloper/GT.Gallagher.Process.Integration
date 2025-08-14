namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities;

public class PrimaryProperties
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public bool State { get; set; }
    public int CreationUserId { get; set; }
    public DateTime CreationDate { get; set; }
}
