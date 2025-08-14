using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy.Handlers;

public class ValidateContentHandler : Handler<ProcessLoadPolicyRequest>
{
    private readonly IProcessLoadPolicyRepository repository;

    public ValidateContentHandler(IProcessLoadPolicyRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadPolicyRequest request)
    {
        var recordsWithObservations = request.ProcessLoadContents.Where(s => s.ProcessLoadPolicy.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in recordsWithObservations)
        {
            var details = new List<ProblemDetail>();
                details.AddRange(rec.ProcessLoadPolicy.ValidationResult.Errors.Select(
                    s => new ProblemDetail(s.PropertyName, s.ErrorMessage)));
            request.ProcessLoadDetails.Add(new ProcessLoadPolicyDetails(rec.RowNumber, rec.ProcessLoadPolicy, details));
        }
        var validRecords = request.ProcessLoadContents.Where(s => !s.ProcessLoadPolicy.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in validRecords)
        {
            request.ProcessLoadDetails.Add(new ProcessLoadPolicyDetails(rec.RowNumber, rec.ProcessLoadPolicy, new ProblemDetail("", "")));
            request.PoliciesToProcess.Add(rec.ProcessLoadPolicy);
        }
        await sucessor?.ProcessRequest(request);
    }
}
