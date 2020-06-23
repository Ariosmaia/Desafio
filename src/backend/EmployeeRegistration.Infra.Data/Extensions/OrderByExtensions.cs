using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Extensions
{
    public static class OrderByExtensions
    {
        public static IQueryable<Employee> AplyOrder(this IQueryable<Employee> query, OrderByDto order = null)
        {
            if(order.OrderBy != null)
            {
                query = query.OrderBy(order.OrderBy);
            }

            return query;
        }
    }
}
