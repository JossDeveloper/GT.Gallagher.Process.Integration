namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;

public class ScheduledProcesses : PrimaryProperties
{
    public int TypeId { get; private set; }
    public string Name { get; private set; }
    public string? PlotName { get; private set; }
    public int? PlotTypeExtensionId { get; private set; }
    public Guid? NotificationCode { get; private set; }
    public Guid? RepositoryCode { get; private set; }
    public Guid? LastProcessCode { get; private set; }
    public string? HistoryPath { get; private set; }
    public Guid? HistoryRepositoryCode { get; private set; }
    public Guid? InternalNotificationCode { get; private set; }
    public string? EndPoint { get; private set; }
}
