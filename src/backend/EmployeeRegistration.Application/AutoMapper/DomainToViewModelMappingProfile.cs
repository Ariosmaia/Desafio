using AutoMapper;
using EmployeeRegistration.Application.ViewModels;
using EmployeeRegistration.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ConvertUsing(
                    e => new EmployeeViewModel()
                    {
                        Id = e.Id,
                        FirstName = e.FullName.FirstName,
                        LastName = e.FullName.LastName,
                        BirthDate = e.BirthDate,
                        Email = e.Email,
                        Gender = e.Gender,
                        Skills = e.EmployeeSkills.ConvertAll(x => new SkillViewModel() { Id = x.Skill.Id, SkillName = x.Skill.SkillName })
                    });
            CreateMap<Skill, SkillViewModel>();
        }
    }
}
