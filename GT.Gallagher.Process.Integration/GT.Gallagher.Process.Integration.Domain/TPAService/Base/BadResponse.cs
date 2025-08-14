using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.TPAService.Base;

public class BadResponse
{
    public string Type { get; private set; }
    public string Title { get; private set; }
    public int Status { get; private set; }
    public List<ProblemDetail>? Details { get; private set; }

    public BadResponse(string type, string title, int status, List<ProblemDetail>? details)
    {
        Type=type;
        Title=title;
        Status=status;
        Details=details;
    }
}
