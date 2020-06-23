using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Utils
{
    public static class AgeUtil
    {
        public static int Age(DateTime birthDate)
        {
            var today = DateTime.Now;

            var age = today.Year - birthDate.Year;

            var month = today.Month - birthDate.Month;

            if (month < 0 || month == 0 && today.Day < birthDate.Day)
            {
                age -= 1;
            }

            return age;
        }
    }
}
