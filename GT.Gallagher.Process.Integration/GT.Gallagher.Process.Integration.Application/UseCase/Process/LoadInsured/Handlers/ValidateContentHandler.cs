using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured.Handlers;

public class ValidateContentHandler : Handler<ProcessLoadInsuredRequest>
{
    private readonly IProcessLoadInsuredRepository repository;

    public ValidateContentHandler(IProcessLoadInsuredRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInsuredRequest request)
    {
        var recordsWithObservations = request.ProcessLoadContents.Where(s => s.ProcessLoadInsured.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in recordsWithObservations)
        {
            var details = new List<ProblemDetail>();
                details.AddRange(rec.ProcessLoadInsured.ValidationResult.Errors.Select(
                    s => new ProblemDetail(s.PropertyName, s.ErrorMessage)));
            request.ProcessLoadDetails.Add(new ProcessLoadInsuredDetails(rec.RowNumber, rec.ProcessLoadInsured, details));
        }
        var validRecords = request.ProcessLoadContents.Where(s => !s.ProcessLoadInsured.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in validRecords)
        {
            request.ProcessLoadDetails.Add(new ProcessLoadInsuredDetails(rec.RowNumber, rec.ProcessLoadInsured, new ProblemDetail("", "")));
            request.InsuredsToProcess.Add(rec.ProcessLoadInsured);
        }
        await sucessor?.ProcessRequest(request);
    }
}
