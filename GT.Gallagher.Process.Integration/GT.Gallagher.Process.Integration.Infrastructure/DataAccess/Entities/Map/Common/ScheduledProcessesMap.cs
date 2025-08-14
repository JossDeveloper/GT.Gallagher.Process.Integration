using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Common;

public class ScheduledProcessesMap : IEntityTypeConfiguration<ScheduledProcesses>
{
    public void Configure(EntityTypeBuilder<ScheduledProcesses> builder)
    {
        builder.Property(s => s.Id)
            .IsRequired()
            .HasColumnName("Id");

        builder.Property(s => s.Code)
            .IsRequired()
            .HasColumnName("Code");

        builder.Property(s => s.TypeId)
            .IsRequired()
            .HasColumnName("ProcessTypeId");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(s => s.PlotName)
            .HasColumnName("PlotName");

        builder.Property(s => s.PlotTypeExtensionId)
            .HasColumnName("PlotTypeExtensionId");

        builder.Property(s => s.NotificationCode)
            .HasColumnName("NotificationCode");

        builder.Property(s => s.RepositoryCode)
            .HasColumnName("RepositoryCode");

        builder.Property(s => s.LastProcessCode)
            .HasColumnName("LastProcessCode");

        builder.Property(s => s.HistoryPath)
            .HasColumnName("HistoryPath");

        builder.Property(s => s.HistoryRepositoryCode)
            .HasColumnName("HistoryRepositoryCode");

        builder.Property(s => s.InternalNotificationCode)
            .HasColumnName("InternalNotificationCode");

        builder.Property(s => s.State)
            .IsRequired()
            .HasColumnName("State");

        builder.Property(s => s.CreationUserId)
            .IsRequired()
            .HasColumnName("CreationUserId");

        builder.Property(s => s.CreationDate)
            .IsRequired()
            .HasColumnName("CreationDate");

        builder.Property(s => s.EndPoint)
            .IsRequired()
            .HasColumnName("EndPoint");

        builder.HasNoKey();
    }
}
