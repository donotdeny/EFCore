using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IServiceProvider serviceProvider)
        {
            _employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            Employee employee = _employeeRepository.FindOne(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            employee.Id = Guid.NewGuid();
            _employeeRepository.Add(employee);
            await _employeeRepository.SaveChange();
            return CreatedAtRoute(
                  "Get",
                  new { Id = employee.Id },
                  employee);
        }
    }
}
