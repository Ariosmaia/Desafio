using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Dtos
{
    public class EmployeeDto
    {
        public Employee Employee { get; set; }
        public IEnumerable <Guid> SkillsSelected { get; set; }
    }
}
