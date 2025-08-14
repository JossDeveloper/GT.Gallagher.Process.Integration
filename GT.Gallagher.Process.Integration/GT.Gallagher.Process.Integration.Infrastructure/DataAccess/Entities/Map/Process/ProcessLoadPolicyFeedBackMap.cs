using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadPolicyFeedBackMap : IEntityTypeConfiguration<ProcessLoadPolicyFeedBack>
{
    public void Configure(EntityTypeBuilder<ProcessLoadPolicyFeedBack> builder)
    {
        builder.Property(s => s.COD_PROCESO)
            .IsRequired()
            .HasColumnName("COD_PROCESO");

        builder.Property(s => s.NRO_FILA)
            .IsRequired()
            .HasColumnName("NRO_FILA");

        builder.Property(s => s.COD_POLIZA_CANAL)
            .IsRequired()
            .HasColumnName("COD_POLIZA_CANAL");

        builder.Property(s => s.TIPO_TRAMITE)
            .IsRequired()
            .HasColumnName("TIPO_TRAMITE");

        builder.Property(s => s.COD_CANAL)
            .IsRequired()
            .HasColumnName("COD_CANAL");

        builder.Property(s => s.NRO_POLIZA_MATRIZ)
            .IsRequired()
            .HasColumnName("NRO_POLIZA_MATRIZ");

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
