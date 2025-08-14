using GT.Gallagher.Process.Integration.Application.Repository.Recurrent;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot.Handlers;

public class GetSftpFilesHandler : Handler<RecurrentPlotRequest>
{
    private readonly IRecurrentPlotRepository repository;

    public GetSftpFilesHandler(IRecurrentPlotRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(RecurrentPlotRequest request)
    {
        request.AddRecord(GetType().Name, "File Path Validate", RecordType.GetSftpFiles);
        int result = repository.CreateDirectoryToSaveFiles();
        request.StepRecords.LastOrDefault().OutputJson = $"{result}";

        if (result != 1)
        {
            request.CodResponse = "02";
            request.TxtResponse = "No se crearon correctamente los directorios del proceso.";
            return;
        }

        var plotName = request.ScheduledProcesses.PlotName ?? "";
            plotName = plotName.Replace("YYYYMMDD", "");

        request.AddRecord(GetType().Name, "Get Sftp Files", RecordType.GetSftpFiles);
        request.SftpFiles = repository.GetSftpFiles(request.RepositoryServer, plotName);
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.SftpFiles);

        if (request.SftpFiles.Any())
        {
            request.AddRecord(GetType().Name, "Put History Sftp Files", RecordType.PutSftpFiles);
            repository.PutSftpFilesHistory(request.RepositoryServer, $"{request.RepositoryServer.Root}/{request.ScheduledProcesses.HistoryPath}", request.SftpFiles);
            request.StepRecords.LastOrDefault().OutputJson = "Succesful deposit.";
        }

        await sucessor?.ProcessRequest(request);
    }
}
