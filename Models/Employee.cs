﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}