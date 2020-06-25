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

            builder
                .HasData(
                    new Skill(new Guid("3f1d528b-0dee-482d-8bc1-1cbcebb90e4f"), "C#"),
                    new Skill(new Guid("da6b3203-3868-4a08-b9c7-a850e0286b5f"), "Java"),
                    new Skill(new Guid("6603c5d1-738d-441f-85d3-d4757f48607d"), "Angular"),
                    new Skill(new Guid("c0c2be94-2972-480d-beb9-4d85d141ffc4"), "SQL"),
                    new Skill(new Guid("177ebcd1-e5a7-418d-bb5c-b3b762b7cca5"), "ASP")
                );

            builder.ToTable("Skills");
        }
    }
}
