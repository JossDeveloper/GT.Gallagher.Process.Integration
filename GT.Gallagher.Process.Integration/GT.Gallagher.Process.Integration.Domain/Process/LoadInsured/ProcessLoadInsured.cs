using GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;

public class ProcessLoadInsured : Entity
{
    public string PolicyChannelCode { get; private set; }
    public string ClientCode { get; private set; }
    public string PersonType { get; private set; }

    public ProcessLoadInsured(string policyChannelCode, string clientCode, string personType)
    {
        PolicyChannelCode = policyChannelCode;
        ClientCode = clientCode;
        PersonType = personType;

        Validate(this, new ProcessLoadInsuredValidator());
    }
}
