using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    public class EmployeeController : BaseController<IEmployeeRepository, Employee>
    {
        public EmployeeController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
