namespace GT.Gallagher.Process.Integration.Application;

public class ApplicationException : Exception
{
    public ApplicationException(string businessMessage) : base(businessMessage) { }
}

