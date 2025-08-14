namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInsured;

public class ProcessLoadInsuredFeedBack
{
    public Guid COD_PROCESO { get; private set; }
    public int NRO_FILA { get; private set; }
    public string COD_POLIZA_CANAL { get; private set; }
    public string COD_CLIENTE { get; private set; }
    public string TIPO_PERSONA { get; private set; }
    public string DETALLE_REGISTRO { get; private set; }
    public string ESTADO { get; private set; }
    public string OBSERVACIONES { get; private set; }
}
