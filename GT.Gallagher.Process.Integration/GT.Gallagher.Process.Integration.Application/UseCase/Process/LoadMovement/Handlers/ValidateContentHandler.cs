using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement.Handlers;

public class ValidateContentHandler : Handler<ProcessLoadMovementRequest>
{
    private readonly IProcessLoadMovementRepository repository;

    public ValidateContentHandler(IProcessLoadMovementRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadMovementRequest request)
    {
        var recordsWithObservations = request.ProcessLoadContents.Where(s => s.ProcessLoadMovement.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in recordsWithObservations)
        {
            var details = new List<ProblemDetail>();
                details.AddRange(rec.ProcessLoadMovement.ValidationResult.Errors.Select(
                    s => new ProblemDetail(s.PropertyName, s.ErrorMessage)));
            request.ProcessLoadDetails.Add(new ProcessLoadMovementDetails(rec.RowNumber, rec.ProcessLoadMovement, details));
        }
        var validRecords = request.ProcessLoadContents.Where(s => !s.ProcessLoadMovement.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in validRecords)
        {
            request.ProcessLoadDetails.Add(new ProcessLoadMovementDetails(rec.RowNumber, rec.ProcessLoadMovement, new ProblemDetail("", "")));
            request.MovementsToProcess.Add(rec.ProcessLoadMovement);
        }
        await sucessor?.ProcessRequest(request);
    }
}
