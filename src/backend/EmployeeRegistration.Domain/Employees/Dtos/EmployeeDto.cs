using EmployeeRegistration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Employees.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto(Guid id, string firstName, string lastName, DateTime birthDate, string email, EGender gender, List<Skill> skills)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Gender = gender;
            Skills = skills;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public EGender Gender { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
