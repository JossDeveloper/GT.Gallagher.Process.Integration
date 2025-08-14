using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadPolicy;

public class ProcessLoadPolicyValidator : AbstractValidator<ProcessLoadPolicy>
{
    public ProcessLoadPolicyValidator()
    {
        RuleFor(s => s.PolicyChannelCode)
            .NotNull().WithMessage("El campo COD POLIZA CANAL es requerido.")
            .NotEmpty().WithMessage("El campo COD POLIZA CANAL es requerido.");

        RuleFor(s => s.ProcessType)
            .NotNull().WithMessage("El campo TIPO TRAMITE es requerido.")
            .NotEmpty().WithMessage("El campo TIPO TRAMITE es requerido.");

        RuleFor(s => s.ProcessSubType)
            .NotNull().WithMessage("El campo SUB TIPO TRAMITE es requerido.")
            .NotEmpty().WithMessage("El campo SUB TIPO TRAMITE es requerido.");

        RuleFor(s => s.ChannelCode)
            .NotEmpty().WithMessage("El campo COD CANAL es requerido.");

        RuleFor(s => s.ChannelAgencyCode)
            .NotEmpty().WithMessage("El campo COD AGENCIA CANAL es requerido.");

        RuleFor(s => s.GallagherAgencyCode)
            .NotEmpty().WithMessage("El campo COD AGENCIA GALLAGHER es requerido.");

        RuleFor(s => s.ChannelFunctionaryCode)
            .NotEmpty().WithMessage("El campo COD FUNCIONARIO CANAL es requerido.");

        RuleFor(s => s.GallagherFunctionaryCode)
            .NotEmpty().WithMessage("El campo COD FUNCIONARIO GALLAGHER es requerido.");

        RuleFor(s => s.MatrixPolicyNumber)
            .NotNull().WithMessage("El campo NRO POLIZA MATRIZ es requerido.")
            .NotEmpty().WithMessage("El campo NRO POLIZA MATRIZ es requerido.");


        RuleFor(s => s.Product)
            .NotNull().WithMessage("El campo PRODUCTO es requerido.")
            .NotEmpty().WithMessage("El campo PRODUCTO es requerido.");

        RuleFor(s => s.Plan)
            .NotNull().WithMessage("El campo PLAN es requerido.")
            .NotEmpty().WithMessage("El campo PLAN es requerido.");


        RuleFor(s => s.ContractNumber)
            .NotEmpty().WithMessage("El campo NRO CONTRATO es requerido.");


        RuleFor(s => s.PolicyType)
            .NotEmpty().WithMessage("El campo TIPO DE POLIZA es requerido.");

        RuleFor(s => s.ContractorCode)
            .NotNull().WithMessage("El campo COD CONTRATANTE es requerido.")
            .NotEmpty().WithMessage("El campo COD CONTRATANTE es requerido.");

        RuleFor(s => s.InsuredCode)
            .NotNull().WithMessage("El campo COD ASEGURADO es requerido.")
            .NotEmpty().WithMessage("El campo COD ASEGURADO es requerido.");

        RuleFor(s => s.ResponsiblePaymentCode)
            .NotNull().WithMessage("El campo COD RESPONSABLE DE PAGO es requerido.")
            .NotEmpty().WithMessage("El campo COD RESPONSABLE DE PAGO es requerido.");

        RuleFor(s => s.InvoicedTo)
            .NotNull().WithMessage("El campo FACTURAR A es requerido.")
            .NotEmpty().WithMessage("El campo FACTURAR A es requerido.");

        RuleFor(s => s.MarkEndorsed)
            .NotEmpty().WithMessage("El campo ENDOSADO es requerido.");


        RuleFor(s => s.ApplicationDate)
            .NotEmpty().WithMessage("El campo FECHA SOLICITUD es requerido.");

        RuleFor(s => s.CiaEmissionDate)
            .NotEmpty().WithMessage("El campo FECHA EMISION COMPAÑIA es requerido.");

        RuleFor(s => s.EffectiveStartDate)
            .NotEmpty().WithMessage("El campo INICIO DE VIGENCIA es requerido.");

        RuleFor(s => s.EffectiveEndDate)
            .NotEmpty().WithMessage("El campo FIN DE VIGENCIA es requerido.");

        RuleFor(s => s.EmissionRightType)
            .NotEmpty().WithMessage("El campo TIPO DERECHO EMISION es requerido.");


        RuleFor(s => s.PaymentMethod)
            .NotEmpty().WithMessage("El campo FORMA DE PAGO es requerido.");

        RuleFor(s => s.InstallmentNumber)
            .NotEmpty().WithMessage("El campo CANTIDAD DE CUOTAS es requerido.")
            .MaximumLength(6).WithMessage("El campo CANTIDAD DE CUOTAS tiene longitud inválida.")
            .Matches(@"^[0-9]{0,6}$").WithMessage("El campo CANTIDAD DE CUOTAS debe ser numérico.");

        RuleFor(s => s.PolicyStatus)
            .NotEmpty().WithMessage("El campo ESTADO POLIZA es requerido.")
            .MaximumLength(4).WithMessage("El campo ESTADO POLIZA tiene longitud inválida.")
            .Matches(@"^[0-9]{0,4}$").WithMessage("El campo ESTADO POLIZA debe ser numérico.");

    }
}
