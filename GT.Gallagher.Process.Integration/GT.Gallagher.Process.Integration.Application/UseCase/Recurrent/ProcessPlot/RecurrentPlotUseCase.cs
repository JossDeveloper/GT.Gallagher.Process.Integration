using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.Application.Repository.Records;
using GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot.Handlers;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot;

public class RecurrentPlotUseCase : IRecurrentPlotUseCase
{
    private readonly ValidateDataInputHandler validateDataInputHandler;
    private readonly IOutputPort<RecurrentPlotResponse> outputPort;
    private readonly IRecordRepository recordRepository;

    public RecurrentPlotUseCase(ValidateDataInputHandler validateDataInputHandler,
        GetScheduledProcessHandler getScheduledProcessHandler,
        GetSftpFilesHandler getSftpFilesHandler,
        SendToProcessHandler sendToProcessHandler,
        SendNotificationHandler sendNotificationHandler,
        IOutputPort<RecurrentPlotResponse> outputPort, 
        IRecordRepository recordRepository)
    {
        validateDataInputHandler
            .SetSucessor(getScheduledProcessHandler)
            .SetSucessor(getSftpFilesHandler)
            .SetSucessor(sendToProcessHandler)
            .SetSucessor(sendNotificationHandler);

        this.validateDataInputHandler = validateDataInputHandler;
        this.outputPort = outputPort;
        this.recordRepository = recordRepository;
    }

    public async Task Execute(RecurrentPlotRequest request)
    {
        try
        {
            request.StartRecord(GetType().Name);
            await validateDataInputHandler.ProcessRequest(request);
            request.EndRecord(GetType().Name);

            if (request.ValidationFailures.Any())
                outputPort.Error(request.ValidationFailures);
            else
            if (request.Details.Any())
                outputPort.Error(request.Details);
            else
            {
                outputPort.Standard(new RecurrentPlotResponse(
                    request.CodResponse,
                    request.TxtResponse,
                    request.Output,
                    request.Details));
            }
        }
        catch (Exception ex)
        {
            request.CodResponse = "-1";
            request.TxtResponse = "Ocurrio un error.";
            request.ErrorRecord(GetType().Name, ex);

            outputPort.ErrorServer($"{request.TxtResponse} {ex.InnerException?.Message ?? ex.Message}");
        }
        finally
        {
            var record = new Record(
                request.Record.Controller,
                request.Record.Action,
                request.Record.RequestJson,
                request.CodResponse,
                request.TxtResponse);
            recordRepository.Add(record, request.StepRecords);
        }
    }
}
