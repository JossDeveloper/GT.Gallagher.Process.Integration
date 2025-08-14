using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.Application.Repository.Records;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient.Handlers;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient;

public class ProcessLoadClientUseCase : IProcessLoadClientUseCase
{
    private readonly ValidateDataInputHandler validateDataInputHandler;
    private readonly IOutputPort<ProcessLoadClientResponse> outputPort;
    private readonly IRecordRepository recordRepository;

    public ProcessLoadClientUseCase(ValidateDataInputHandler validateDataInputHandler,
        GetScheduledProcessHandler getScheduledProcessHandler,
        GenerateMainProcessHandler generateMainProcessHandler,
        ReadContentFileHandler readContentFileHandler,
        BuildContentHandler buildContentHandler,
        ValidateContentHandler validateContentHandler,
        SaveProcessHandler saveProcessHandler,
        BuildDataProcessHandler buildDataProcessHandler,
        SendToProcessHandler sendToProcessHandler,
        GetFeedBackHandler getFeedBackHandler,
        SendNotificationHandler sendNotificationHandler,
        EndProcessHandler endProcessHandler,
        IOutputPort<ProcessLoadClientResponse> outputPort,
        IRecordRepository recordRepository)
    {
        validateDataInputHandler
            .SetSucessor(getScheduledProcessHandler)
            .SetSucessor(generateMainProcessHandler)
            .SetSucessor(readContentFileHandler)
            .SetSucessor(buildContentHandler)
            .SetSucessor(validateContentHandler)
            .SetSucessor(saveProcessHandler)
            .SetSucessor(buildDataProcessHandler)
            .SetSucessor(sendToProcessHandler)
            .SetSucessor(getFeedBackHandler)
            .SetSucessor(sendNotificationHandler)
            .SetSucessor(endProcessHandler);

        this.validateDataInputHandler = validateDataInputHandler;
        this.outputPort = outputPort;
        this.recordRepository = recordRepository;
    }

    public async Task Execute(ProcessLoadClientRequest request)
    {
        try
        {
            request.StartRecord(GetType().Name);
            validateDataInputHandler.ProcessRequest(request);
            request.EndRecord(GetType().Name);

            if (request.ValidationFailures.Any())
                outputPort.Error(request.ValidationFailures);
            else 
            if (request.Details.Any())
                outputPort.Error(request.Details);
            else
            {
                outputPort.Standard(new ProcessLoadClientResponse(
                    request.CodResponse,
                    request.TxtResponse,
                    request.Details,
                    request.Output));
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
