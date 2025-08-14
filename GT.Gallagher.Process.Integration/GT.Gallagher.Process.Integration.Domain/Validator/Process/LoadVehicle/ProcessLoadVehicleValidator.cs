using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadVehicle;

public class ProcessLoadVehicleValidator : AbstractValidator<ProcessLoadVehicle>
{
    public ProcessLoadVehicleValidator()
    {
        RuleFor(s => s.PolicyChannelCode)
            .NotNull().WithMessage("El campo COD POLIZA CANAL es requerido.")
            .NotEmpty().WithMessage("El campo COD POLIZA CANAL es requerido.");

        RuleFor(s => s.VehicleChannelCode)
            .NotNull().WithMessage("El campo COD VEHICULO CANAL es requerido.")
            .NotEmpty().WithMessage("El campo COD VEHICULO CANAL es requerido.");

        RuleFor(s => s.CertificateNumber)
            .NotNull().WithMessage("El campo NRO CERTIFICADO es requerido.")
            .NotEmpty().WithMessage("El campo NRO CERTIFICADO es requerido.");

        RuleFor(s => s.CommercialValue)
            .NotNull().WithMessage("El campo VALOR COMERCIAL es requerido.")
            .NotEmpty().WithMessage("El campo VALOR COMERCIAL es requerido.");

        /*
        RuleFor(s => s.CommercialValueWeighted)
            .NotEmpty().WithMessage("El campo CommercialValueWeighted es requerido.");
        */

        RuleFor(s => s.ClientRate)
            .NotEmpty().WithMessage("El campo TASA CLIENTE es requerido.");

        RuleFor(s => s.CiaRate)
            .NotEmpty().WithMessage("El campo TASA CIA es requerido.");

        RuleFor(s => s.ClientNetPremium)
            .NotEmpty().WithMessage("El campo PRIMA NETA CLIENTE es requerido.");

        RuleFor(s => s.ClientEmissionRight)
            .NotEmpty().WithMessage("El campo DERECHO EMISION CLIENTE es requerido.");

        RuleFor(s => s.ClientTotalPremium)
            .NotEmpty().WithMessage("El campo PRIMA TOTAL CLIENTE es requerido.");

        RuleFor(s => s.CiaNetPremium)
            .NotEmpty().WithMessage("El campo PRIMA NETA CIA es requerido.");

        RuleFor(s => s.CiaEmissionRight)
            .NotEmpty().WithMessage("El campo DERECHO EMISION CIA es requerido.");

        RuleFor(s => s.CiaTotalPremium)
            .NotEmpty().WithMessage("El campo PRIMA TOTAL CIA es requerido.");

        RuleFor(s => s.ChannelCommissionRate)
            .NotEmpty().WithMessage("El campo TASA COMISION CANAL es requerido.");

        RuleFor(s => s.BrokerCommissionRate)
            .NotEmpty().WithMessage("El campo TASA COMISION BROKER es requerido.");


        RuleFor(s => s.Coverage)
            .NotNull().WithMessage("El campo COBERTURA es requerido.")
            .NotEmpty().WithMessage("El campo COBERTURA es requerido.");

        RuleFor(s => s.UseVehicle)
            .NotNull().WithMessage("El campo USO es requerido.")
            .NotEmpty().WithMessage("El campo USO es requerido.");

        /*
        RuleFor(s => s.Plaque)
            .NotEmpty().WithMessage("El campo Plaque es requerido.");
        */

        RuleFor(s => s.ClassVehicle)
            .NotNull().WithMessage("El campo CLASE es requerido.")
            .NotEmpty().WithMessage("El campo CLASE es requerido.");

        RuleFor(s => s.TypeVehicle)
            .NotNull().WithMessage("El campo TIPO es requerido.")
            .NotEmpty().WithMessage("El campo TIPO es requerido.");

        RuleFor(s => s.Brand)
            .NotNull().WithMessage("El campo MARCA es requerido.")
            .NotEmpty().WithMessage("El campo MARCA es requerido.");

        RuleFor(s => s.Model)
            .NotNull().WithMessage("El campo MODELO es requerido.")
            .NotEmpty().WithMessage("El campo MODELO es requerido.");

        /*
        RuleFor(s => s.Version)
            .NotEmpty().WithMessage("El campo VERSION es requerido.");
        */

        RuleFor(s => s.SerialNumber)
            .NotNull().WithMessage("El campo NRO SERIE es requerido.")
            .NotEmpty().WithMessage("El campo NRO SERIE es requerido.");

        /*
        RuleFor(s => s.EngineNumber)
            .NotEmpty().WithMessage("El campo NRO MOTOR es requerido.");
        */

        RuleFor(s => s.Seats)
            .NotNull().WithMessage("El campo NRO ASIENTOS es requerido.")
            .NotEmpty().WithMessage("El campo NRO ASIENTOS es requerido.")
            .MaximumLength(2).WithMessage("El campo NRO ASIENTOS tiene longitud inválida.")
            .Matches(@"^[0-9]{0,2}$").WithMessage("El campo NRO ASIENTOS debe ser numérico.");

        RuleFor(s => s.Antique)
            .NotNull().WithMessage("El campo ANTIGUEDAD es requerido.")
            .NotEmpty().WithMessage("El campo ANTIGUEDAD es requerido.");

        RuleFor(s => s.ManufactureYear)
            .NotEmpty().WithMessage("El campo AÑO FABRICACION es requerido.");


        RuleFor(s => s.CertificateStartDate)
            .NotEmpty().WithMessage("El campo FECHA INICIO CERTIFICADO es requerido.");

        RuleFor(s => s.CertificateEndDate)
            .NotEmpty().WithMessage("El campo FECHA FIN CERTIFICADO es requerido.");


        RuleFor(s => s.MarkSinkholeUse)
            .NotEmpty().WithMessage("El campo FLAG SOCAVON es requerido.");

        RuleFor(s => s.MarkOptionalUse)
            .NotEmpty().WithMessage("El campo FLAG FACULTATIVO es requerido.");

        RuleFor(s => s.MarkApprovalManagement)
            .NotEmpty().WithMessage("El campo GESTION DE VISTO BUENO es requerido.");

        RuleFor(s => s.CertificateStatus)
            .NotNull().WithMessage("El campo ESTADO CERTIFICADO es requerido.")
            .NotEmpty().WithMessage("El campo ESTADO CERTIFICADO es requerido.")
            .MaximumLength(4).WithMessage("El campo ESTADO CERTIFICADO tiene longitud inválida.")
            .Matches(@"^[0-9]{0,4}$").WithMessage("El campo ESTADO CERTIFICADO debe ser numérico.");

    }
}
