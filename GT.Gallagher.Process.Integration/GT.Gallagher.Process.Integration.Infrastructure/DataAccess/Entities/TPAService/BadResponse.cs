using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.TPAService;

public class BadResponse
{
    [JsonProperty(PropertyName = "type")]
    public string Type { get; private set; }
    [JsonProperty(PropertyName = "title")]
    public string Title { get; private set; }
    [JsonProperty(PropertyName = "status")]
    public int Status { get; private set; }
    [JsonProperty(PropertyName = "details")]
    public List<ProblemDetail>? Details { get; private set; }
}
