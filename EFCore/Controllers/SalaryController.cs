using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    public class SalaryController : BaseController<ISalaryRepository, Salary>
    {
        public SalaryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet("/employee/{employeeId}")]
        public IActionResult GetSalaryByEmployeeId(Guid employeeId)
        {
            try
            {
                IQueryable<Salary> res = _repo.GetByEmployeeId(employeeId);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500, _messageResponse);
            }
        }
    }
}
