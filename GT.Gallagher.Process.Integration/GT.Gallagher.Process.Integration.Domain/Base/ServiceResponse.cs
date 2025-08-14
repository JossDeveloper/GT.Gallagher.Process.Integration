namespace GT.Gallagher.Process.Integration.Domain.Base;

public class ServiceResponse
{
    public int StatusCode { get; private set; }
    public string Content { get; private set; }

    public ServiceResponse(int statusCode, string content)
    {
        StatusCode = statusCode;
        Content = content;
    }
}
