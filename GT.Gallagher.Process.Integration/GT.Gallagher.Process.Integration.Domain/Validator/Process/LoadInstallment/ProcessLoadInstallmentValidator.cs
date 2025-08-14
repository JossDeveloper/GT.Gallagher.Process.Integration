using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadInstallment;

public class ProcessLoadInstallmentValidator : AbstractValidator<ProcessLoadInstallment>
{
    public ProcessLoadInstallmentValidator()
    {
        RuleFor(s => s.PolicyChannelCode)
            .NotNull().WithMessage("El campo COD POLIZA CANAL es requerido.")
            .NotEmpty().WithMessage("El campo COD POLIZA CANAL es requerido.");

        RuleFor(s => s.InstallmentNumber)
            .NotNull().WithMessage("El campo NRO CUOTA es requerido.")
            .NotEmpty().WithMessage("El campo NRO CUOTA es requerido.");

        RuleFor(s => s.InstallmentStatus)
            .NotNull().WithMessage("El campo ESTADO CUOTA es requerido.")
            .NotEmpty().WithMessage("El campo ESTADO CUOTA es requerido.");

        RuleFor(s => s.EmissionDate)
            .NotEmpty().WithMessage("El campo FECHA DE EMISION es requerido.");

        RuleFor(s => s.InstallmentNetPremium)
            .NotEmpty().WithMessage("El campo PRIMA NETA CUOTA es requerido.");

        RuleFor(s => s.InstallmentTotalPremium)
            .NotEmpty().WithMessage("El campo PRIMA TOTAL CUOTA es requerido.");
    }
}
