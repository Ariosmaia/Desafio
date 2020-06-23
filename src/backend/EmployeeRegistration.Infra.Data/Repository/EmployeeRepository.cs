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

        public IEnumerable<Employee> GetAllCustom(FilterDto filter = null)
        {
            var employee = Db.Employees.AsNoTracking().Include(e =>
                    e.EmployeeSkills).ThenInclude(e => e.Skill);

            return employee;
        }

        public override Employee GetById(Guid id)
        {
            var employee = Db.Employees.AsNoTracking().Include(e =>
                     e.EmployeeSkills).ThenInclude(e => e.Skill).FirstOrDefault(x => x.Id == id);

            return employee;
        }


        public void UpdateCustom(EmployeeDto obj)
        {
            var employee = Db.Employees.AsNoTracking().Include(e =>
                     e.EmployeeSkills).FirstOrDefault(x => x.Id == obj.Employee.Id);



            Db.TryUpdateManyToMany(employee.EmployeeSkills, obj.SkillsSelected
                .Select(x => new EmployeeSkill
                {
                    SkillId = x,
                    EmployeeId = obj.Employee.Id
                }), x => x.SkillId);
        }
    }
}
