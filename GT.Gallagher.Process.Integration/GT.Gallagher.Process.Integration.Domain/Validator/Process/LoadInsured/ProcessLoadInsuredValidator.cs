using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadInsured;

public class ProcessLoadInsuredValidator : AbstractValidator<ProcessLoadInsured>
{
    public ProcessLoadInsuredValidator()
    {
        RuleFor(s => s.PolicyChannelCode)
            .NotNull().WithMessage("El campo COD POLIZA CANAL es requerido.")
            .NotEmpty().WithMessage("El campo COD POLIZA CANAL es requerido.");

        RuleFor(s => s.ClientCode)
            .NotNull().WithMessage("El campo COD CLIENTE es requerido.")
            .NotEmpty().WithMessage("El campo COD CLIENTE es requerido.");

        RuleFor(s => s.PersonType)
            .NotNull().WithMessage("El campo TIPO TERCERO es requerido.")
            .NotEmpty().WithMessage("El campo TIPO TERCERO es requerido.")
            .MaximumLength(4).WithMessage("El campo TIPO TERCERO tiene longitud inválida.")
            .Matches(@"^[0-9]{0,4}$").WithMessage("El campo TIPO TERCERO debe ser numérico.");
    }
}
