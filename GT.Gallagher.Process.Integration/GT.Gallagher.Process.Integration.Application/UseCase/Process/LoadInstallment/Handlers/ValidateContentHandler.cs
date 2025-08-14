using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment.Handlers;

public class ValidateContentHandler : Handler<ProcessLoadInstallmentRequest>
{
    private readonly IProcessLoadInstallmentRepository repository;

    public ValidateContentHandler(IProcessLoadInstallmentRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInstallmentRequest request)
    {
        var recordsWithObservations = request.ProcessLoadContents.Where(s => s.ProcessLoadInstallment.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in recordsWithObservations)
        {
            var details = new List<ProblemDetail>();
                details.AddRange(rec.ProcessLoadInstallment.ValidationResult.Errors.Select(
                    s => new ProblemDetail(s.PropertyName, s.ErrorMessage)));
            request.ProcessLoadDetails.Add(new ProcessLoadInstallmentDetails(rec.RowNumber, rec.ProcessLoadInstallment, details));
        }
        var validRecords = request.ProcessLoadContents.Where(s => !s.ProcessLoadInstallment.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in validRecords)
        {
            request.ProcessLoadDetails.Add(new ProcessLoadInstallmentDetails(rec.RowNumber, rec.ProcessLoadInstallment, new ProblemDetail("", "")));
            request.InstallmentsToProcess.Add(rec.ProcessLoadInstallment);
        }
        await sucessor?.ProcessRequest(request);
    }
}
