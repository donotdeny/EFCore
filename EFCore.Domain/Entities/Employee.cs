﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public Guid? CurrentDepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
