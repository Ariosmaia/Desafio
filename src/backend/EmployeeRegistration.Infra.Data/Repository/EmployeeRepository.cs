using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Repository;
using EmployeeRegistration.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeRegistrationContext context) : base(context)
        {
        }
    }
}
