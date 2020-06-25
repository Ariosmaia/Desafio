using AutoMapper;
using EmployeeRegistration.Application.ViewModels;
using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Dtos;
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



            CreateMap<PagedDto, PagedViewModel>()
              .ConvertUsing(e => new PagedViewModel()
              {
                  Total = e.Total,
                  TotalPages = e.TotalPages,
                  SizePage = e.SizePage,
                  NumberPage = e.NumberPage,
                  Result = e.Result
                    .ConvertAll(
                        x => new EmployeeViewModel
                        {
                            Id = x.Id,
                            FirstName = x.FullName.FirstName,
                            LastName = x.FullName.LastName,
                            BirthDate = x.BirthDate,
                            Email = x.Email,
                            Gender = x.Gender,
                            Skills = x.EmployeeSkills.ConvertAll(x => new SkillViewModel() { Id = x.Skill.Id, SkillName = x.Skill.SkillName })
                        }),
                  Previous = e.Previous,
                  Next = e.Next
              }) ;
        }
    }
}
