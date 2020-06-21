using EmployeeRegistration.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees
{
    public class EmployeeSkill
    {
        protected EmployeeSkill() { }
        public EmployeeSkill(Guid employeeId, Guid skillId)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
        }

        public Guid EmployeeId { get; private set; }
        public Guid SkillId { get; private set; }

        public virtual Employee Employee { get; private set; }
        public virtual Skill Skill { get; private set; }

    }
}
