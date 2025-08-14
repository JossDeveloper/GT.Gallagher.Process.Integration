using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Domain.Records;

public class Record
{
    public Guid RecordCode { get => Guid.NewGuid(); }
    public string Controller { get; private set; }
    public string Action { get; private set; }
    public string? Service { get => $"api/{Controller.Replace("Controller", "")}/{Action}"; }
    public string RequestJson { get; private set; }
    public string? CodResponse { get; private set; }
    public string? TxtResponse { get; private set; }
    public DateTime CreationDate { get => DateTime.Now; }

    public Record(string controller, string action, object request, string? codResponse, string? txtResponse)
    {
        Controller = controller;
        Action = action;
        RequestJson = JsonConvert.SerializeObject(request);
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }

    public Record(string controller, string action, string requestJson, string? codResponse, string? txtResponse)
    {
        Controller = controller;
        Action = action;
        RequestJson = requestJson;
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
