namespace GT.Gallagher.Process.Integration.Infrastructure;

public class InfrastructureException : Exception
{
    public InfrastructureException(string businessMessage) : base(businessMessage) { }
}

