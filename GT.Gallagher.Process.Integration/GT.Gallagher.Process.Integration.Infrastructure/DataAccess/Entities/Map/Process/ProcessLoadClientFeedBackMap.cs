using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadClientFeedBackMap : IEntityTypeConfiguration<ProcessLoadClientFeedBack>
{
    public void Configure(EntityTypeBuilder<ProcessLoadClientFeedBack> builder)
    {
        builder.Property(s => s.COD_PROCESO)
            .IsRequired()
            .HasColumnName("COD_PROCESO");

        builder.Property(s => s.NRO_FILA)
            .IsRequired()
            .HasColumnName("NRO_FILA");

        builder.Property(s => s.COD_CLIENTE)
            .IsRequired()
            .HasColumnName("COD_CLIENTE");

        builder.Property(s => s.TIPO_PERSONA)
            .IsRequired()
            .HasColumnName("TIPO_PERSONA");

        builder.Property(s => s.TIPO_DOCUMENTO)
            .IsRequired()
            .HasColumnName("TIPO_DOCUMENTO");

        builder.Property(s => s.NRO_DOCUMENTO)
            .IsRequired()
            .HasColumnName("NRO_DOCUMENTO");

        builder.Property(s => s.DETALLE_REGISTRO)
            .IsRequired()
            .HasColumnName("DETALLE_REGISTRO");

        builder.Property(s => s.ESTADO)
            .IsRequired()
            .HasColumnName("ESTADO");

        builder.Property(s => s.OBSERVACIONES)
            .IsRequired()
            .HasColumnName("OBSERVACIONES");

        builder.HasNoKey();
    }
}
