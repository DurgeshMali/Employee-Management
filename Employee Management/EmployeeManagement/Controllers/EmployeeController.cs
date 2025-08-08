using EmployeeManagement.Models.RequestModels;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            var EmployeeId = await _employeeService.AddEmployeeAsync(employeeRequest);
            return Ok(new 
            { 
                Message = "You have successfully created an Account",
                EmployeeId 
            });
        }
    }
}
