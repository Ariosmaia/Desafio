using EmployeeRegistration.Application.ViewModels;
using EmployeeRegistration.Domain.Employees.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeRegistration.Application.Interfaces
{
    public interface IEmployeeAppService
    {
        void Add(EmployeeViewModel employeeViewModel);
        EmployeeViewModel GetById(Guid id);
        PagedViewModel GetAll(FilterViewModel filter = null, OrderByViewModel order = null, PaginationViewModel pagination = null);
        void Update(EmployeeViewModel employeeViewModel);
        void Remove(Guid id);
        IEnumerable<EmployeeViewModel> Find(Expression<Func<EmployeeViewModel, bool>> predicate);
    }
}
