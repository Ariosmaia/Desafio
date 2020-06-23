using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Application.ViewModels
{
    public class FilterViewModel
    {
        public int Age { get; set; }
        public int Gender { get; set; }
        public List<SkillViewModel>? Skills { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

    }
}
