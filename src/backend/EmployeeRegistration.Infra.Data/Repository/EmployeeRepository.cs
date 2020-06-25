using Dapper;
using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Employees.Repository;
using EmployeeRegistration.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EmployeeRegistration.Infra.Data.Extensions;
using EmployeeRegistration.Domain.Employees.Dtos;

namespace EmployeeRegistration.Infra.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeRegistrationContext context) : base(context)
        {
        }

        public override IEnumerable<Employee> GetAll()
        {
            var employee = Db.Employees.AsNoTracking().Include(e =>
                    e.EmployeeSkills).ThenInclude(e => e.Skill);

            return employee;
        }

        public PagedDto GetAllCustom(FilterDto filter = null, OrderByDto order = null, PaginationDto pagination = null)
        {
            var employeePagination = Db.Employees.AsNoTracking()
                .AplyFilter(filter)
                .AplyOrder(order)
                .Include(e =>
                    e.EmployeeSkills).ThenInclude(e => e.Skill)
                .ToPaged(pagination);

            return employeePagination;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return Db.Skills.ToList();
        }

        public override Employee GetById(Guid id)
        {
            var employee = Db.Employees.AsNoTracking().Include(e =>
                     e.EmployeeSkills).ThenInclude(e => e.Skill).FirstOrDefault(x => x.Id == id);

            return employee;
        }

        public override void Update(Employee obj)
        {
            var oldEmployee = Db.Employees.AsNoTracking().Include(p => p.EmployeeSkills).ThenInclude(e => e.Skill).First(p => p.Id == obj.Id);

            oldEmployee.FullName = obj.FullName;
            oldEmployee.BirthDate = obj.BirthDate;
            oldEmployee.Gender = obj.Gender;
            oldEmployee.Email = obj.Email;


            var skillsSelected = new List<Guid>();

            foreach (var item in obj.EmployeeSkills)
            {
                skillsSelected.Add(item.SkillId);
            }



            var employeeDb = Db.Employees.AsNoTracking().Include(e =>
                     e.EmployeeSkills).First(x => x.Id == obj.Id);



            Db.TryUpdateManyToMany(oldEmployee.EmployeeSkills, skillsSelected
                .Select(x => new EmployeeSkill
                {
                    SkillId = x,
                    EmployeeId = obj.Id
                }), x => x.SkillId);

            base.Update(oldEmployee);
        }

    }
}
