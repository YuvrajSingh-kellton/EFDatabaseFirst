using System;
using System.Collections.Generic;

namespace EFDBFirst.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeEducations = new HashSet<EmployeeEducation>();
        }

        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? EmpAddress { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
