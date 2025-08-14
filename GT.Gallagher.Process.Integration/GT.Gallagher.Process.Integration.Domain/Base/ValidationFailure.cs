namespace GT.Gallagher.Process.Integration.Domain.Base;

public class ValidationFailure
{
    public string PropertyName { get; private set; }
    public string ErrorMessage { get; private set; }

    public ValidationFailure(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}
