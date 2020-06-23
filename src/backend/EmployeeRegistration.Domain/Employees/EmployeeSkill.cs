using EmployeeRegistration.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees
{
    public class EmployeeSkill
    {
        public EmployeeSkill() { }
    
        public Guid EmployeeId { get; set; }
        public Guid SkillId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Skill Skill { get; set; }

    }
}
