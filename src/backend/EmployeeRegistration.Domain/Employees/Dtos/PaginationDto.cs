using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Dtos
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 25;
    }
}
