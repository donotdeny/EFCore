using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Impl.Sql.Implements
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
