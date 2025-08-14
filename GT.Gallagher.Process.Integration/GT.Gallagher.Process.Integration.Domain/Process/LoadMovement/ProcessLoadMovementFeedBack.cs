namespace GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

public class ProcessLoadMovementFeedBack
{
    public Guid COD_PROCESO { get; private set; }
    public int NRO_FILA { get; private set; }
    public string COD_POLIZA_CANAL { get; private set; }
    public string NRO_MOVIMIENTO { get; private set; }
    public string COD_MOVIMIENTO { get; private set; }
    public string DETALLE_REGISTRO { get; private set; }
    public string ESTADO { get; private set; }
    public string OBSERVACIONES { get; private set; }
}
