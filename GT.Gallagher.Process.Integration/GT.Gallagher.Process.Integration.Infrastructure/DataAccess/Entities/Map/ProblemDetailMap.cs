using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map;

public class ProblemDetailMap : IEntityTypeConfiguration<ProblemDetail>
{
    public void Configure(EntityTypeBuilder<ProblemDetail> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasMaxLength(100);

        builder.Property(p => p.Message)
            .IsRequired()
            .HasColumnName("Message")
            .HasMaxLength(200);

        builder.HasNoKey();
    }
}

