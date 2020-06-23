using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Dtos;
using EmployeeRegistration.Domain.Enums;
using EmployeeRegistration.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<Employee> AplyFilter(this IQueryable<Employee> query, FilterDto filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = query.Where(n => n.FullName.FirstName.Contains(filter.Name) || n.FullName.LastName.Contains(filter.Name));
                }

                if (filter.Age != 0)
                {
                    query = query.Where(i => AgeUtil.Age(i.BirthDate) == filter.Age);
                }

                if (filter.Gender != 0)
                {
                    query = query.Where(g => (int)g.Gender == filter.Gender);
                }
            }

            return query;
        }
    }
}
