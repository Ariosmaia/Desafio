using EmployeeRegistration.Domain.Core.Notifications;
using EmployeeRegistration.Domain.Employees.Dtos;
using EmployeeRegistration.Domain.Employees.Repository;
using EmployeeRegistration.Domain.Handlers;
using EmployeeRegistration.Domain.Interfaces;
using EmployeeRegistration.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Employees.Commands
{
    public class EmployeeCommandHandler : CommandHandler,
        IRequestHandler<RegisterEmployeeCommand, bool>,
        IRequestHandler<UpdateEmployeeCommand, bool>,
        IRequestHandler<DeleteEmployeeCommand, bool>

    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediatorHandler _mediator;

        public EmployeeCommandHandler(IEmployeeRepository employeeRepository,
                                    IUnitOfWork uow,
                                    INotificationHandler<DomainNotification> notifications,
                                    IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(RegisterEmployeeCommand message, CancellationToken cancellationToken)
        {

            var name = new Name(message.FirstName, message.LastName);
            var employeeSkillList = new List<EmployeeSkill>();

            foreach (var skill in message.Skills)
            {
                var id = message.Id;
                var employeeSkill = new EmployeeSkill() { EmployeeId =  id, SkillId = skill.Id };
                employeeSkillList.Add(employeeSkill);
            }

            var employee = new Employee(message.Id, name, message.BirthDate, message.Email, message.Gender, employeeSkillList);

            if (!EmployeeValid(employee)) return Task.FromResult(false);

            _employeeRepository.Add(employee);

            Commit();
          
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateEmployeeCommand message, CancellationToken cancellationToken)
        {

            if (!EmployeeExists(message.Id, message.MessageType)) return Task.FromResult(false);

            var name = new Name(message.FirstName, message.LastName);
            var employeeSkillList = new List<EmployeeSkill>();

            foreach (var skill in message.Skills)
            {
                var id = message.Id;
                var employeeSkill = new EmployeeSkill() { EmployeeId = id, SkillId = skill.Id };
                employeeSkillList.Add(employeeSkill);
            }

            var employee = new Employee(message.Id, name, message.BirthDate, message.Email, message.Gender, employeeSkillList);

            if (!EmployeeValid(employee)) return Task.FromResult(false);

            var skillsSelected = new List<Guid>();

            foreach (var item in employee.EmployeeSkills)
            {
                skillsSelected.Add(item.SkillId);
            }

            var updateDto = new EmployeeDto
            {
                Employee = employee,
                SkillsSelected = skillsSelected
            };

            _employeeRepository.UpdateCustom(updateDto);

            

            return Task.FromResult(true);
        }

        public Task<bool> Handle(DeleteEmployeeCommand message, CancellationToken cancellationToken)
        {
            if (!EmployeeExists(message.Id, message.MessageType)) return Task.FromResult(false);

            _employeeRepository.Remove(message.Id);

            Commit();
          
            return Task.FromResult(true);
        }

        private bool EmployeeValid(Employee employee)
        {
            if (employee.IsValid()) return true;

            NotificarValidacoesErro(employee.ValidationResult);
            return false;
        }

        private bool EmployeeExists(Guid id, string messageType)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee != null) return true;

            _mediator.PublishEvent(new DomainNotification(messageType, "Funcionário não encontrado."));
            return false;
        }

    }
}
