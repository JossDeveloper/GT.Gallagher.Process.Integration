namespace GT.Gallagher.Process.Integration.Domain.Base;

public class ValidateRedex
{
    public bool IsValid { get; private set; }
    public string PropertyName { get; private set; }
    public string ErrorMessage { get; private set; }

    public ValidateRedex(bool isValid, string propertyName, string errorMessage)
    {
        IsValid = isValid;
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}

