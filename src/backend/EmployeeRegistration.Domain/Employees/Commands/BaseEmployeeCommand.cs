using EmployeeRegistration.Domain.Core.Commands;
using EmployeeRegistration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Commands
{
    public abstract class BaseEmployeeCommand : Command
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Email { get; protected set; }
        public EGender Gender { get; protected set; }
        public ICollection<Skill> Skills { get; protected set; }
    }
}
