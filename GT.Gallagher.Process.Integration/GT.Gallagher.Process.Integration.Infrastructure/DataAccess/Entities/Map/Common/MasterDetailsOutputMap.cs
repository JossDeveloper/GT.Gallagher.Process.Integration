using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Common;

public class MasterDetailsOutputMap : IEntityTypeConfiguration<MasterDetailsOutput>
{
    public void Configure(EntityTypeBuilder<MasterDetailsOutput> builder)
    {
        builder.Property(s => s.MasterCode)
            .IsRequired()
            .HasColumnName("MasterCode");

        builder.Property(s => s.RowNumber)
            .IsRequired()
            .HasColumnName("RowNumber");

        builder.Property(s => s.TextString)
            .IsRequired()
            .HasColumnName("TextString");

        builder.Property(s => s.Details)
            .IsRequired()
            .HasColumnName("Details");

        builder.Property(s => s.State)
            .IsRequired()
            .HasColumnName("State");

        builder.HasNoKey();
    }
}
