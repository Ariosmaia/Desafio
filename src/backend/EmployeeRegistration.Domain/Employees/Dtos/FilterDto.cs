using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Dtos
{
    public class FilterDto
    {
        public int Age { get; set; }
        public int Gender { get; set; }
        public List<Skill> Skills { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

    }
}
