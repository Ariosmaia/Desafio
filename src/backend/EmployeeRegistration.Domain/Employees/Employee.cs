using EmployeeRegistration.Domain.Core.Models;
using EmployeeRegistration.Domain.Enums;
using EmployeeRegistration.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeRegistration.Domain.Employees
{
    public class Employee : Entity<Employee>
    {

        public Name FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public EGender Gender { get; private set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; private set; }


        private static bool IsOverEighteen(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddDays(-18);
        }


        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        #region Validations

        private void Validate()
        {
            ValidateBirthDate();
            ValidateEmail();
            ValidateGender();
            ValidateEmployeeSkills();
            ValidationResult = Validate(this);

            ValidateFullname();
        }

        private void ValidateFullname()
        {
            foreach (var error in FullName.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        private void ValidateBirthDate()
        {
            RuleFor(e => e.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória")
                .LessThan(e => DateTime.Now).WithMessage("A data de nascimento deve estar no passado")
                .Must(IsOverEighteen).WithMessage("O funcionário deve ser maior de 18 anos");

        }

        private void ValidateEmail()
        {
            RuleFor(e => e.Email)
                .EmailAddress().WithMessage("E-mail inválido");
        }

        private void ValidateGender()
        {
            RuleFor(e => e.Gender)
                .NotEmpty().WithMessage("O sexo é obrigatório");
        }

        private void ValidateEmployeeSkills()
        {
            RuleFor(e => e.EmployeeSkills)
               .NotEmpty().WithMessage("Infome pelo menos uma habilidade");
        }

        #endregion

    }
}
