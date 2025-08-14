using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.TPAService;

public class TokenResponse
{
    [JsonProperty(PropertyName = "access_token")]
    public string Access_token { get; private set; }
    [JsonProperty(PropertyName = "expires_in")]
    public int Expires_in { get; private set; }
}
