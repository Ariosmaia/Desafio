using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Application.ViewModels
{
    public class PaginationViewModel
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 25;
    }

}
