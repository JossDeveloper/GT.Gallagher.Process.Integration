using GT.Gallagher.Process.Integration.Domain.Base;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace GT.Gallagher.Process.Integration.Infrastructure.Helper;

public class UseService
{
    public static RestRequest MountRequest(string source, Method method)
    {
        var request = new RestRequest(source, method);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "application/json");

        return request;
    }

    public static RestRequest MountRequestFormData(string source, Method method)
    {
        var request = new RestRequest(source, method);
        request.AddHeader("Content-Type", "multipart/form-data");
        request.AddHeader("Accept", "text/plain");

        return request;
    }

    public static TResponse GetResponse<TResponse>(RestRequest request, string url, int maxTimeOut) where TResponse : new()
    {
        var client = new RestClient(new RestClientOptions(url) { MaxTimeout = maxTimeOut });

        var response = client.Execute<TResponse>(request);

        if (response.Content is null || response.ResponseStatus == ResponseStatus.TimedOut || response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.GatewayTimeout || response.ResponseStatus == ResponseStatus.Error)
            throw new ApplicationException($" {response.ResponseStatus} - {response.ErrorException.Message ?? response.ErrorMessage}");

        return JsonConvert.DeserializeObject<TResponse>(response.Content);
    }

    public static async Task<ServiceResponse> GetResponseAsync(RestRequest request, string url, int maxTimeOut)
    {
        var client = new RestClient(new RestClientOptions(url) { MaxTimeout = maxTimeOut });

        var response = await client.ExecuteAsync(request);

        return new ServiceResponse((int)response.StatusCode, response.Content);
    }

    public static async Task<(TOk?, TBad?)> GetTpaResponseAsync<TOk, TBad>(RestRequest request, string url, int maxTimeOut) where TOk : new() where TBad : new()
    {
        var client = new RestClient(new RestClientOptions(url) { MaxTimeout = maxTimeOut });

        var response = await client.ExecuteAsync(request, new CancellationTokenSource().Token);

        if ((int)response.StatusCode == 200)
        {
            TOk goodResponse = JsonConvert.DeserializeObject<TOk>(response.Content);
            return (goodResponse, default(TBad));
        }
        else if ((int)response.StatusCode == 400 || (int)response.StatusCode == 401)
        {
            TBad badResponse = JsonConvert.DeserializeObject<TBad>(response.Content);
            return (default(TOk), badResponse);
        }
        else
            return (default(TOk), default(TBad));
    }
}

