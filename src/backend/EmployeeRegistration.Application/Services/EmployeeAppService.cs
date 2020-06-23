using AutoMapper;
using EmployeeRegistration.Application.Interfaces;
using EmployeeRegistration.Application.ViewModels;
using EmployeeRegistration.Domain.Employees.Commands;
using EmployeeRegistration.Domain.Employees.Dtos;
using EmployeeRegistration.Domain.Employees.Repository;
using EmployeeRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeRegistration.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediatorHandler _bus;

        public EmployeeAppService(IMapper mapper, IEmployeeRepository employeeRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _bus = bus;
        }

        public PagedViewModel GetAll(FilterViewModel filter = null, OrderByViewModel order = null, PaginationViewModel pagination = null)
        {
            var employees = _employeeRepository.GetAllCustom(
                _mapper.Map<FilterDto>(filter), 
                _mapper.Map<OrderByDto>(order),
                _mapper.Map<PaginationDto>(pagination)
                );
            return _mapper.Map<PagedViewModel>(employees);
        }

        public EmployeeViewModel GetById(Guid id)
        {
            return _mapper.Map<EmployeeViewModel>(_employeeRepository.GetById(id));
        }

        public IEnumerable<EmployeeViewModel> Find(Expression<Func<EmployeeViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(EmployeeViewModel employeeViewModel)
        {
            var registerEmployeeCommand = _mapper.Map<RegisterEmployeeCommand>(employeeViewModel);
            _bus.SendCommand(registerEmployeeCommand);
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
            var updateEmployeeCommand = _mapper.Map<UpdateEmployeeCommand>(employeeViewModel);
            _bus.SendCommand(updateEmployeeCommand);
        }

        public void Remove(Guid id)
        {
            _bus.SendCommand(new DeleteEmployeeCommand(id));
        }
    }
}
