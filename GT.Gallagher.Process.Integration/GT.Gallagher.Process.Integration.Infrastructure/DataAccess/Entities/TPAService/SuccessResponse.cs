using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.TPAService;

public class SuccessResponse
{
    [JsonProperty(PropertyName = "codResponse")]
    public string CodResponse { get; private set; }
    [JsonProperty(PropertyName = "txtResponse")]
    public string TxtResponse { get; private set; }
    [JsonProperty(PropertyName = "details")]
    public List<ProblemDetail> Details { get; private set; }
}
