using EmployeeRegistration.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees
{
    public class Skill : Entity<Skill>
    {
        protected Skill() {}
        public Skill(Guid id, string skillName)
        {
            Id = id;
            SkillName = skillName;
        }

        public string SkillName { get; private set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; private set; }

        public override bool IsValid()
        {
            RuleFor(e => e.SkillName)
                 .NotEmpty().WithMessage("O nome da habilidade é obrigatória");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;

        }
    }
}
