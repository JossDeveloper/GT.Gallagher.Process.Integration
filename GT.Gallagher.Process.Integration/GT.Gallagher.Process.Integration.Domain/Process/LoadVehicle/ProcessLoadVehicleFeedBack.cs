namespace GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

public class ProcessLoadVehicleFeedBack
{
    public Guid COD_PROCESO { get; private set; }
    public int NRO_FILA { get; private set; }
    public string COD_POLIZA_CANAL { get; private set; }
    public string COD_VEHICULO_CANAL { get; private set; }
    public string NRO_CERTIFICADO { get; private set; }
    public string PLACA { get; private set; }
    public string DETALLE_REGISTRO { get; private set; }
    public string ESTADO { get; private set; }
    public string OBSERVACIONES { get; private set; }
}
