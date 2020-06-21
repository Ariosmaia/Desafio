using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Mappings
{
    public class SkillMapping : EntityTypeConfiguration<Skill>
    {
        public override void Map(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(e => e.SkillName)
                 .HasColumnType("varchar(20)")
                 .IsRequired();

            builder.Ignore(e => e.CascadeMode);

            builder.Ignore(e => e.ValidationResult);

            builder.ToTable("Skills");
        }
    }
}
