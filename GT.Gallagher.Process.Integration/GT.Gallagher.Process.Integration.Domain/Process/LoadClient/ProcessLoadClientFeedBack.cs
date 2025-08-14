namespace GT.Gallagher.Process.Integration.Domain.Process.LoadClient;

public class ProcessLoadClientFeedBack
{
    public Guid COD_PROCESO { get; private set; }
    public int NRO_FILA { get; private set; }
    public string COD_CLIENTE { get; private set; }
    public string TIPO_PERSONA { get; private set; }
    public string TIPO_DOCUMENTO { get; private set; }
    public string NRO_DOCUMENTO { get; private set; }
    public string DETALLE_REGISTRO { get; private set; }
    public string ESTADO { get; private set; }
    public string OBSERVACIONES { get; private set; }
}
