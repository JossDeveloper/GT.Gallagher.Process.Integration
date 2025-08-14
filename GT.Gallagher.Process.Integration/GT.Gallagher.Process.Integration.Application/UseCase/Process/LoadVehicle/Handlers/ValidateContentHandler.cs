using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle.Handlers;

public class ValidateContentHandler : Handler<ProcessLoadVehicleRequest>
{
    private readonly IProcessLoadVehicleRepository repository;

    public ValidateContentHandler(IProcessLoadVehicleRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadVehicleRequest request)
    {
        var recordsWithObservations = request.ProcessLoadContents.Where(s => s.ProcessLoadVehicle.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in recordsWithObservations)
        {
            var details = new List<ProblemDetail>();
                details.AddRange(rec.ProcessLoadVehicle.ValidationResult.Errors.Select(
                    s => new ProblemDetail(s.PropertyName, s.ErrorMessage)));
            request.ProcessLoadDetails.Add(new ProcessLoadVehicleDetails(rec.RowNumber, rec.ProcessLoadVehicle, details));
        }
        var validRecords = request.ProcessLoadContents.Where(s => !s.ProcessLoadVehicle.ValidationResult.Errors.Any()).ToList();
        foreach (var rec in validRecords)
        {
            request.ProcessLoadDetails.Add(new ProcessLoadVehicleDetails(rec.RowNumber, rec.ProcessLoadVehicle, new ProblemDetail("", "")));
            request.VehiclesToProcess.Add(rec.ProcessLoadVehicle);
        }
        await sucessor?.ProcessRequest(request);
    }
}
