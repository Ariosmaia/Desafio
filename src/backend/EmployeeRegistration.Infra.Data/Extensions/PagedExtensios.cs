using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Extensions
{
    public static class PagedExtensios
    {
        public static PagedDto ToPaged(this IQueryable<Employee> query, PaginationDto pagination)
        {

            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pagination.Size);
            return new PagedDto
            {
                Total = query.Count(),
                TotalPages = totalPages,
                NumberPage = pagination.Page,
                SizePage = pagination.Size,
                Result = query
                    .Skip(pagination.Size * (pagination.Page - 1))
                    .Take(pagination.Size).ToList(),
                Previous = (pagination.Page > 1) ? 
                    $"employees?size={pagination.Page-1}&page={pagination.Size}": "", 
                Next = (pagination.Page < totalPages) ?
                    $"employees?size={pagination.Page+1}&page={pagination.Size}" : "", 
            };
        }
    }
}
