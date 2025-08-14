namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Token;

public class TokenResponse
{
    public string Access_token { get; private set; }
    public int Expires_in { get; private set; }

    public TokenResponse(string access_token, int expires_in)
    {
        Access_token = access_token;
        Expires_in = expires_in;
    }
}

