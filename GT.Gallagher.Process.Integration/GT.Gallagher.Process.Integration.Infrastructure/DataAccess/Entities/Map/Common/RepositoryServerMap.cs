using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Common;

public class RepositoryServerMap : IEntityTypeConfiguration<RepositoryServer>
{
    public void Configure(EntityTypeBuilder<RepositoryServer> builder)
    {
        builder.Property(s => s.Id)
            .IsRequired()
            .HasColumnName("Id");

        builder.Property(s => s.Code)
            .IsRequired()
            .HasColumnName("Code");

        builder.Property(s => s.Description)
            .IsRequired()
            .HasColumnName("Description");

        builder.Property(s => s.Server)
            .IsRequired()
            .HasColumnName("Server");

        builder.Property(s => s.User)
            .HasColumnName("User");

        builder.Property(s => s.Password)
            .HasColumnName("Password");

        builder.Property(s => s.SshHostKey)
            .HasColumnName("SshHostKey");

        builder.Property(s => s.Root)
            .HasColumnName("Root");

        builder.Property(s => s.State)
            .IsRequired()
            .HasColumnName("State");

        builder.Property(s => s.CreationUserId)
            .IsRequired()
            .HasColumnName("CreationUserId");

        builder.Property(s => s.CreationDate)
            .IsRequired()
            .HasColumnName("CreationDate");

        builder.HasNoKey();
    }
}
