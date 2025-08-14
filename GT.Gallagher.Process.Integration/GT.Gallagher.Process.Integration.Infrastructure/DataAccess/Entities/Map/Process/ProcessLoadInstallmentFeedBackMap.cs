using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInstallment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadInstallmentFeedBackMap : IEntityTypeConfiguration<ProcessLoadInstallmentFeedBack>
{
    public void Configure(EntityTypeBuilder<ProcessLoadInstallmentFeedBack> builder)
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

        builder.Property(s => s.NRO_CUOTA)
            .IsRequired()
            .HasColumnName("NRO_CUOTA");

        builder.Property(s => s.NRO_OPERACION)
            .IsRequired()
            .HasColumnName("NRO_OPERACION");

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
