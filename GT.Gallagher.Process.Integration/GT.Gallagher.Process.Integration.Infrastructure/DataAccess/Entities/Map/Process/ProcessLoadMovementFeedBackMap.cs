using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadMovement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadMovementFeedBackMap : IEntityTypeConfiguration<ProcessLoadMovementFeedBack>
{
    public void Configure(EntityTypeBuilder<ProcessLoadMovementFeedBack> builder)
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

        builder.Property(s => s.NRO_MOVIMIENTO)
            .IsRequired()
            .HasColumnName("NRO_MOVIMIENTO");

        builder.Property(s => s.COD_MOVIMIENTO)
            .IsRequired()
            .HasColumnName("COD_MOVIMIENTO");

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
