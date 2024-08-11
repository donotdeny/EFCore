using System;
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
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public Guid? CurrentDepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }
}
