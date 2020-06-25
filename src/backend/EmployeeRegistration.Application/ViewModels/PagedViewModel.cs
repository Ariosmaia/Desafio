using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Application.ViewModels
{
    public class PagedViewModel
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int SizePage { get; set; }
        public int NumberPage { get; set; }
        public List<EmployeeViewModel> Result { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}
