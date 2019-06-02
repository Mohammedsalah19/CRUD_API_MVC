using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeeInMVC
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Postion { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }

    }
}