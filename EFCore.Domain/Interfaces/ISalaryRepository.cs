using EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Interfaces
{
    public interface ISalaryRepository : IBaseRepository<Salary>
    {
        IQueryable<Salary> GetByEmployeeId(Guid employeeId);
    }
}
