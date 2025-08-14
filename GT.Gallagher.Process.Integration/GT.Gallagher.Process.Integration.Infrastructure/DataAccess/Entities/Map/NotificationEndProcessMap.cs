using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map;

public class NotificationEndProcessMap : IEntityTypeConfiguration<NotificationEndProcess>
{
    public void Configure(EntityTypeBuilder<NotificationEndProcess> builder)
    {
        builder.Property(p => p.Subject)
            .IsRequired()
            .HasColumnName("Subject");

        builder.Property(p => p.HtmlBody)
            .IsRequired()
            .HasColumnName("BodyName");

        builder.Property(p => p.EmailTo)
            .HasColumnName("to");

        builder.Property(p => p.EmailCc)
            .HasColumnName("cc");

        builder.Property(p => p.EmailBcc)
            .HasColumnName("bcc");

        builder.HasNoKey();
    }
}
