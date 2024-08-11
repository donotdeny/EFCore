using EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
    }
}
