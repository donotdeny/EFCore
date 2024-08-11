using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Entities
{
    public class Salary : BaseEntity
    {
        public decimal SalaryReceive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CurrentEmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
