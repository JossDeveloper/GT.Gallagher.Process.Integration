using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Validator.Process;

namespace GT.Gallagher.Process.Integration.Domain.Process;

public class ProcessLoadInput : Entity
{
    public int UserId { get; private set; }
    public Guid ProcessCode { get; private set; }
    public Guid UniqueName { get; private set; }
    public FileInput FileInput { get; private set; }

    public ProcessLoadInput(int userId, Guid processCode, Guid uniqueName, FileInput fileInput)
    {
        UserId = userId;
        ProcessCode = processCode;
        UniqueName = uniqueName;
        FileInput = fileInput;
        Validate(this, new ProcessLoadInputValidator());
    }
}
