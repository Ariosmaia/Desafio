using EmployeeRegistration.Domain.Employees.Dtos;
using EmployeeRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        PagedDto GetAllCustom(FilterDto filter = null, OrderByDto order = null, PaginationDto pagination = null);

        IEnumerable<Skill> GetAllSkills();

    }
}
