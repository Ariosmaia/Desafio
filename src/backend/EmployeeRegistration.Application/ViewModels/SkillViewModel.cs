using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegistration.Application.ViewModels
{
    public class SkillViewModel
    {
        [Key]

        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string SkillName { get; set; }

    }
}