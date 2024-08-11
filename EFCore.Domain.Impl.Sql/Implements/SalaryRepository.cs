using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Impl.Sql.Implements
{
    public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IQueryable<Salary> GetByEmployeeId(Guid employeeId)
        {
            return _appDbContext.Salary.Where(item => item.CurrentEmployeeId  == employeeId);
        }
    }
}
