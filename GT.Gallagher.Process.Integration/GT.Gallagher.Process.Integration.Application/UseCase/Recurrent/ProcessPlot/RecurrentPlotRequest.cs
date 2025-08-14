using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using GT.Gallagher.Process.Integration.Domain.Recurrent.ProcessPlot;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot;

public class RecurrentPlotRequest : StandardRequest
{
    public RecurrentPlotInput Input { get; private set; }
    public ScheduledProcesses ScheduledProcesses { get; set; }
    public RepositoryServer RepositoryServer { get; set; }
    public List<SftpFile> SftpFiles { get; set; } = new();
    public ProcessLoadOutput Output { get; set; }

    public RecurrentPlotRequest(Record record, RecurrentPlotInput input)
    {
        Record = record;
        Input = input;
    }
}
