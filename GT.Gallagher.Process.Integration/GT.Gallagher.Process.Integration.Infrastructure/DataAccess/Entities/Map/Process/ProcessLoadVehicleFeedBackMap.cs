using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadVehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadVehicleFeedBackMap : IEntityTypeConfiguration<ProcessLoadVehicleFeedBack>
{
    public void Configure(EntityTypeBuilder<ProcessLoadVehicleFeedBack> builder)
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

        builder.Property(s => s.COD_VEHICULO_CANAL)
            .IsRequired()
            .HasColumnName("COD_VEHICULO_CANAL");

        builder.Property(s => s.NRO_CERTIFICADO)
            .IsRequired()
            .HasColumnName("NRO_CERTIFICADO");

        builder.Property(s => s.PLACA)
            .IsRequired()
            .HasColumnName("PLACA");

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
