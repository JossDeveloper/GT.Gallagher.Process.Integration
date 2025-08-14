namespace GT.Gallagher.Process.Integration.Infrastructure.External;

public static class TpaConfig
{
    public static string UrlGtService = Environment.GetEnvironmentVariable("GT_SERVICE_URL");
    public static string EndPointMailSend = Environment.GetEnvironmentVariable("GT_SERVICE_ENDPOINT_MAIL_SEND");
    public static int ExpirationTime = int.Parse(Environment.GetEnvironmentVariable("GT_SERVICE_EXPIRATION_TIME"));
}
