using EmployeeRegistration.Domain.Core.ValueObjects;
using FluentValidation;

namespace EmployeeRegistration.Domain.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override bool IsValid()
        {
            RuleFor(fn => fn.FirstName)
                .NotEmpty().WithMessage("O nome é obrigatprio")
                .Length(2, 20).WithMessage("O nome precisa ter entre 2 e 150 caracteres");

            RuleFor(fn => fn.LastName)
                .NotEmpty().WithMessage("O sobrenome é obrigatprio")
                .Length(2, 20).WithMessage("O sobrenome precisa ter entre 2 e 150 caracteres");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
