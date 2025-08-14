namespace GT.Gallagher.Process.Integration.Domain.Base;

public class ProblemDetail
{
    public string Title { get; private set; }
    public string Message { get; private set; }

    public ProblemDetail(string title, string message)
    {
        Title = title;
        Message = message;
    }
}

