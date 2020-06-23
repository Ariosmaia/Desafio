using EmployeeRegistration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Commands
{
    public class DeleteEmployeeCommand : BaseEmployeeCommand
    {

        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
