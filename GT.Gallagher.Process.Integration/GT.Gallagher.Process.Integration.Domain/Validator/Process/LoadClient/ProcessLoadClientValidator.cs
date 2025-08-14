using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process.LoadClient;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadClient;

public class ProcessLoadClientValidator : AbstractValidator<ProcessLoadClient>
{
    public ProcessLoadClientValidator()
    {
        RuleFor(s => s.ClientCode)
            .NotNull().WithMessage("El campo COD CLIENTE es requerido.")
            .NotEmpty().WithMessage("El campo COD CLIENTE es requerido.");

        RuleFor(s => s.PersonType)
            .NotNull().WithMessage("El campo TIPO PERSONA es requerido.")
            .NotEmpty().WithMessage("El campo TIPO PERSONA es requerido.")
            .MaximumLength(4).WithMessage("El campo TIPO PERSONA tiene longitud inválida.")
            .Matches(@"^[0-9]{0,4}$").WithMessage("El campo TIPO PERSONA debe ser numérico.");

        RuleFor(s => s.DocumentType)
            .NotNull().WithMessage("El campo TIPO DOCUMENTO es requerido.")
            .NotEmpty().WithMessage("El campo TIPO DOCUMENTO es requerido.")
            .MaximumLength(4).WithMessage("El campo TIPO DOCUMENTO tiene longitud inválida.")
            .Matches(@"^[0-9]{0,4}$").WithMessage("El campo TIPO DOCUMENTO debe ser numérico.");

        RuleFor(s => s.DocumentNumber)
            .NotEmpty().WithMessage("El campo NRO DOCUMENTO es requerido.")
            .MaximumLength(15).WithMessage("El campo NRO DOCUMENTO tiene longitud inválida.");

        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("El campo NOMBRE es requerido.");

        RuleFor(s => s.ContactPerson)
            .NotEmpty().WithMessage("El campo PERSONA DE CONTACTO es requerido.");

        RuleFor(s => s.Phone)
            .NotEmpty().WithMessage("El campo TEL CELULAR es requerido.");

        RuleFor(s => s.Address)
            .NotEmpty().WithMessage("El campo DIRECCION es requerido.");

        RuleFor(s => s.Email)
            .NotEmpty().WithMessage("El campo EMAIL es requerido.");

        RuleFor(s => s.ClientType)
            .NotNull().WithMessage("El campo TIPO CLIENTE es requerido.")
            .NotEmpty().WithMessage("El campo TIPO CLIENTE es requerido.")
            .MaximumLength(6).WithMessage("El campo TIPO CLIENTE tiene longitud inválida.")
            .Matches(@"^[0-9]{0,6}$").WithMessage("El campo TIPO CLIENTE debe ser numérico.");

    }
}
