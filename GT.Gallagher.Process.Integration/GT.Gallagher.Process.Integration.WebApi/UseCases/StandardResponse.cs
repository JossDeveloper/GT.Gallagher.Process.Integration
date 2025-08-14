using GlobalTpa.Extension.Startup.WebApi.Model;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases;

public class StandardResponse
{
    public string CodResponse { get; set; }
    public string TxtResponse { get; set; }
    public List<ProblemDetail> Details { get; set; }

    public StandardResponse()
    {
        Details = new List<ProblemDetail>();
    }
}

