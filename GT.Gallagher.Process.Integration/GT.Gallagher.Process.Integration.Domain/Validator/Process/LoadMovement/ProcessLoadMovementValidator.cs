using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadMovement;

public class ProcessLoadMovementValidator : AbstractValidator<ProcessLoadMovement>
{
    public ProcessLoadMovementValidator()
    {
        RuleFor(s => s.PolicyChannelCode)
            .NotNull().WithMessage("El campo COD POLIZA CANAL es requerido.")
            .NotEmpty().WithMessage("El campo COD POLIZA CANAL es requerido.");

        RuleFor(s => s.MovementNumber)
            .NotNull().WithMessage("El campo NRO MOVIMIENTO es requerido.")
            .NotEmpty().WithMessage("El campo NRO MOVIMIENTO es requerido.");

        RuleFor(s => s.MovementCode)
            .NotEmpty().WithMessage("El campo COD MOVIMIENTO es requerido.");

        RuleFor(s => s.FunctionaryCode)
            .NotEmpty().WithMessage("El campo COD FUNCIONARIO es requerido.");

        RuleFor(s => s.MovementDate)
            .NotNull().WithMessage("El campo FECHA MOVIMIENTO es requerido.")
            .NotEmpty().WithMessage("El campo FECHA MOVIMIENTO es requerido.");
    }
}
