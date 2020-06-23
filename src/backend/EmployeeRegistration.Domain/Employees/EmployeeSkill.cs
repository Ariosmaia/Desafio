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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is EmployeeSkill)) return false;
            var ps = obj as EmployeeSkill;
            return (this.EmployeeId == ps.EmployeeId) && (this.SkillId == ps.SkillId);
        }

        public override int GetHashCode()
        {
            return this.EmployeeId.GetHashCode() + this.SkillId.GetHashCode() + 765;
        }

    }
}
