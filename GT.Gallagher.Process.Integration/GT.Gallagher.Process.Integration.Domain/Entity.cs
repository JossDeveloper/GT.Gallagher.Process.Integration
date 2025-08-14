using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.Gallagher.Process.Integration.Domain;

public abstract class Entity
{
    [NotMapped]
    public bool IsValid { get; private set; }
    [NotMapped]
    public ValidationResult ValidationResult { get; private set; }

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);

        return IsValid = ValidationResult.IsValid;
    }
}

