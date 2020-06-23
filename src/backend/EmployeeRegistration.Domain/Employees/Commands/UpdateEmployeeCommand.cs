using EmployeeRegistration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Commands
{
    public class UpdateEmployeeCommand : BaseEmployeeCommand
    {

        public UpdateEmployeeCommand(
            Guid id,
            string firstName, 
            string lastName, 
            DateTime birthDate, 
            string email, 
            EGender gender,
            ICollection<Skill> skills
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Gender = gender;
            Skills = skills;
        }
    }
}
