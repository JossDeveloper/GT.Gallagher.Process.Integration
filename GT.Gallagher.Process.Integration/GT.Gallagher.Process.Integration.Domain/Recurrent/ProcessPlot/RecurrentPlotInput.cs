using GT.Gallagher.Process.Integration.Domain.Validator.Recurrent.ProcessPlot;

namespace GT.Gallagher.Process.Integration.Domain.Recurrent.ProcessPlot;

public class RecurrentPlotInput : Entity
{
    public int UserId { get; private set; }
    public int ProcessId { get; private set; }

    public RecurrentPlotInput(int userId, int processId)
    {
        UserId = userId;
        ProcessId = processId;
        Validate(this, new RecurrentPlotValidator());
    }
}
