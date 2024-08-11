using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    public class DepartmentController : BaseController<IDepartmentRepository, Department>
    {
        public DepartmentController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
