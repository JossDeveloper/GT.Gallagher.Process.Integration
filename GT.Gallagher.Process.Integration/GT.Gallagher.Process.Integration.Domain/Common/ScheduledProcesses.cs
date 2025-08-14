namespace GT.Gallagher.Process.Integration.Domain.Common;

public class ScheduledProcesses
{
    public int Id { get; private set; }
    public Guid Code { get; private set; }
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

    public ScheduledProcesses(int id, Guid code, int typeId, string name, string? plotName, int? plotTypeExtensionId, Guid? notificationCode, Guid? repositoryCode, Guid? lastProcessCode, string? historyPath, Guid? historyRepositoryCode, Guid? internalNotificationCode, string? endPoint)
    {
        Id = id;
        Code = code;
        TypeId = typeId;
        Name = name;
        PlotName = plotName;
        PlotTypeExtensionId = plotTypeExtensionId;
        NotificationCode = notificationCode;
        RepositoryCode = repositoryCode;
        LastProcessCode = lastProcessCode;
        HistoryPath = historyPath;
        HistoryRepositoryCode = historyRepositoryCode;
        InternalNotificationCode = internalNotificationCode;
        EndPoint = endPoint;
    }
}
