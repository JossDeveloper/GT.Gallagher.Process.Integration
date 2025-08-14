using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.TPAService.Base;

public class SuccessResponse
{
    public string CodResponse { get; private set; }
    public string TxtResponse { get; private set; }
    public List<ProblemDetail> Details { get; private set; }
}
