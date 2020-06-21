using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Mappings
{
    public class EmployeeSkillMapping : EntityTypeConfiguration<EmployeeSkill>
    {
        public override void Map(EntityTypeBuilder<EmployeeSkill> builder)
        {

            builder.HasKey(sc => new { sc.EmployeeId, sc.SkillId});

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeSkills)
                .HasForeignKey("EmployeeId")
                .IsRequired();

            builder.HasOne(x => x.Skill)
                .WithMany(x => x.EmployeeSkills)
                .HasForeignKey("SkillId")
                .IsRequired();

            builder.ToTable("EmployeeSkills");
        }
    }
}
