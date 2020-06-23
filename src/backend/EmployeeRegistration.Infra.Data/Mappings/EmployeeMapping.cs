using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Domain.Enums;
using EmployeeRegistration.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Infra.Data.Mappings
{
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public override void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(e => e.FullName)
                .Property(e => e.FirstName)
                .IsRequired(true)
                .HasColumnType("varchar(20)")
                .HasColumnName("FirstName");

            builder.OwnsOne(e => e.FullName)
               .Property(e => e.LastName)
               .IsRequired(true)
               .HasColumnType("varchar(20)")
               .HasColumnName("LastName");

            builder.OwnsOne(e => e.FullName)
                .Ignore(e => e.CascadeMode);

            builder.Property(e => e.BirthDate)
              .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(100)");

            builder.HasQueryFilter(p => !p.Deleted);

            builder.Property(e => e.Gender)
                .IsRequired();

            builder.Ignore(e => e.CascadeMode);

            builder.Ignore(e => e.ValidationResult);

            builder.ToTable("Employees");
        }
    }
}
