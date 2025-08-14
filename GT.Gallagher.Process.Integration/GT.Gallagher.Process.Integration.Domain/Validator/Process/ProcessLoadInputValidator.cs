using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Process;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Process;

public class ProcessLoadInputValidator : AbstractValidator<ProcessLoadInput>
{
    public ProcessLoadInputValidator()
    {
        RuleFor(s => s.UserId)
            .InclusiveBetween(1, int.MaxValue)
            .WithMessage("Value not be valid.");

        RuleFor(s => s.ProcessCode)
            .NotEmpty().WithMessage("Value not be empty.")
            .NotEqual(Guid.Empty).WithMessage("Value not be valid.")
            .Must(s => s.ToString("N").Length == 32).WithMessage("Value not be valid.");

        RuleFor(s => s.UniqueName)
            .NotEmpty().WithMessage("Value not be empty.")
            .NotEqual(Guid.Empty).WithMessage("Value not be valid.")
            .Must(s => s.ToString("N").Length == 32).WithMessage("Value not be valid.");

        RuleFor(s => s.FileInput.Name)
            .NotEmpty().WithMessage("Value not be empty.")
            //.Must(s => Path.GetFileNameWithoutExtension(s).StartsWith("EVV2")).WithMessage("Nomenclature not be valid.")
            .Must(s => Path.GetFileNameWithoutExtension(s).Length > 5).WithMessage("Length Name not be valid.");

        RuleFor(s => s.FileInput.ContentType)
            .NotEmpty().WithMessage("Value not be empty.");
            //.Equal("text/plain").WithMessage("Value not be valid.");

        RuleFor(s => s.FileInput.Bytes)
            .NotEmpty().WithMessage("Value not be empty.")
            .Must(s => s?.Length > 0).WithMessage("Value not be valid.");
    }
}
