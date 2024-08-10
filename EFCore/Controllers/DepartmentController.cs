using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IServiceProvider serviceProvider, IBaseRepository<Department> repo) : base(serviceProvider, repo)
        {
        }
    }
}
