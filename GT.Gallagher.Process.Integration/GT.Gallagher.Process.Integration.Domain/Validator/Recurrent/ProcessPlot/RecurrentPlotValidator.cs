using FluentValidation;
using GT.Gallagher.Process.Integration.Domain.Recurrent.ProcessPlot;

namespace GT.Gallagher.Process.Integration.Domain.Validator.Recurrent.ProcessPlot;

public class RecurrentPlotValidator : AbstractValidator<RecurrentPlotInput>
{
    public RecurrentPlotValidator()
    {
        RuleFor(s => s.UserId)
            .NotNull().WithMessage("Value not valid.")
            .InclusiveBetween(1, int.MaxValue).WithMessage("Value not be valid.");

        RuleFor(s => s.ProcessId)
            .NotNull().WithMessage("Value not valid.")
            .InclusiveBetween(1, int.MaxValue).WithMessage("Value not be valid.");
    }
}
