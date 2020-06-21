using System.IO;
using EmployeeRegistration.Domain.Employees;
using EmployeeRegistration.Infra.Data.Extensions;
using EmployeeRegistration.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeRegistration.Infra.Data.Context
{
    public class EmployeeRegistrationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EmployeeMapping());
            modelBuilder.AddConfiguration(new SkillMapping());
            modelBuilder.AddConfiguration(new EmployeeSkillMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        }
    }
}
