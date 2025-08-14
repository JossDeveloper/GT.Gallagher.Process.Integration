using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Gallagher.Process;

public class ServiceProcessLoadResponse
{
    [JsonProperty(PropertyName = "output")]
    public ProcessLoadOutput? Output { get; private set; }
}
