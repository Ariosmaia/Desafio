using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Dtos
{
    public class PagedDto
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int SizePage { get; set; }
        public int NumberPage { get; set; }
        public List<Employee> Result { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}
