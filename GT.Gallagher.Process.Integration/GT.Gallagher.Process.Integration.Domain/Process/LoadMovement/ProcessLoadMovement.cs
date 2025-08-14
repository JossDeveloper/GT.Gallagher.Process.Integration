using GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadMovement;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

public class ProcessLoadMovement : Entity
{
    public string PolicyChannelCode { get; private set; }
    public string MovementNumber { get; private set; }
    public string MovementCode { get; private set; }
    public string FunctionaryCode { get; private set; }
    public string MovementDate { get; private set; }
    public string? Comment { get; private set; }
    public string? Support { get; private set; }

    public ProcessLoadMovement(string policyChannelCode, string movementNumber, string movementCode, string functionaryCode, string movementDate, string? comment, string? support)
    {
        PolicyChannelCode = policyChannelCode;
        MovementNumber = movementNumber;
        MovementCode = movementCode;
        FunctionaryCode = functionaryCode;
        MovementDate = movementDate;
        Comment = comment;
        Support = support;

        Validate(this, new ProcessLoadMovementValidator());
    }
}
