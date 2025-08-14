using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured.Handlers;

public class ValidateDataInputHandler : Handler<ProcessLoadInsuredRequest>
{
    public override async Task ProcessRequest(ProcessLoadInsuredRequest request)
    {
        request.AddRecord(GetType().Name, "Validate Data Input", RecordType.InputValidation);
        request.ValidationFailures.AddRange(request.Input.ValidationResult.Errors.Select(s => new ValidationFailure(s.PropertyName, s.ErrorMessage)));
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.ValidationFailures);

        if (request.ValidationFailures.Any())
        {
            request.CodResponse = "01";
            request.TxtResponse = "Validación de Estructura de Datos";
            return;
        }
        await sucessor?.ProcessRequest(request);
    }
}
