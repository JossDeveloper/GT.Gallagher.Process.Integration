using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Gallagher.Process;

public class ProcessLoadOutput
{
    [JsonProperty(PropertyName = "MasterCode")]
    public Guid MasterCode { get; private set; }
    [JsonProperty(PropertyName = "Name")]
    public string Name { get; private set; }
    [JsonProperty(PropertyName = "QuantityRows")]
    public int QuantityRows { get; private set; }
}
