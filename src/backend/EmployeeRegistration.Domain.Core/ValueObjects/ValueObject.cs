using FluentValidation;
using FluentValidation.Results;

namespace EmployeeRegistration.Domain.Core.ValueObjects
{
    public abstract class ValueObject<T> : AbstractValidator<T> where T : ValueObject<T>
    {
        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        public ValueObject()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
