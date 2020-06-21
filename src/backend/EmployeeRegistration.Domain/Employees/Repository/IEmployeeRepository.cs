using EmployeeRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
