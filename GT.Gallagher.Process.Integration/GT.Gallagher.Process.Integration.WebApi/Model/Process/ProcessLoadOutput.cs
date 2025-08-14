namespace GT.Gallagher.Process.Integration.WebApi.Model.Process;

public class ProcessLoadOutput
{
    public Guid MasterCode { get; private set; }
    public string Name { get; private set; }
    public int QuantityRows { get; private set; }

    public ProcessLoadOutput(Guid masterCode, string name, int quantityRows)
    {
        MasterCode = masterCode;
        Name = name;
        QuantityRows = quantityRows;
    }
}
