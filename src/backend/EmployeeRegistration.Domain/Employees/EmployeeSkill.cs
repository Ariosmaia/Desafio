using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees
{
    public class EmployeeSkill
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public virtual Guid SkillId { get; private set; }
        public virtual Skill Skill { get; private set; }

    }
}
