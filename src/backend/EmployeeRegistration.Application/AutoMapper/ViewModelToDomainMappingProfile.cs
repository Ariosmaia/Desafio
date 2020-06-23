using AutoMapper;
using EmployeeRegistration.Application.ViewModels;
using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Commands;
using EmployeeRegistration.Domain.Employees.Dtos;
using EmployeeRegistration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EmployeeViewModel, RegisterEmployeeCommand>()
                .ConvertUsing(e => new RegisterEmployeeCommand(e.FirstName, e.LastName, e.BirthDate, e.Email, e.Gender, e.Skills.ConvertAll(x => new Skill(x.Id, x.SkillName))));

           CreateMap<EmployeeViewModel, UpdateEmployeeCommand>()
                .ConvertUsing(e => new UpdateEmployeeCommand(e.Id, e.FirstName, e.LastName, e.BirthDate, e.Email, e.Gender, e.Skills.ConvertAll(x => new Skill(x.Id, x.SkillName))));

            CreateMap<EmployeeViewModel, DeleteEmployeeCommand>()
                .ConvertUsing(e => new DeleteEmployeeCommand(e.Id));


            CreateMap<FilterViewModel, FilterDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<OrderByViewModel, OrderByDto>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PaginationViewModel, PaginationDto>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }

    }
}
