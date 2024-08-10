using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(IServiceProvider serviceProvider, IEmployeeRepository employeeRepository) : base(serviceProvider, employeeRepository)
        {
        }
    }
}
