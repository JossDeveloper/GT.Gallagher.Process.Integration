using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;

namespace GT.Gallagher.Process.Integration.Domain.Gallagher.Process;

public class ServiceProcessLoadResponse : SuccessResponse
{
    public ProcessLoadOutput? Output { get; private set; }
}
