using EmployeeManagement.Models.RequestModels;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeRequest employeeRequest)
        {
            var EmployeeId = await _employeeService.AddEmployeeAsync(employeeRequest);
            var response = new
            {
                Message = "You have successfully created an Account",
                EmployeeId
            };
            return Created("/employee/login", response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> EmployeeLogIn([FromBody] EmployeeLoginRequest employeeLoginRequest)
        {
            var token = await _employeeService.EmployeeLogInAsync(employeeLoginRequest);
            if(token == null)
            {
                var response = new
                {
                    message = "Unauthorized Person"
                };
                return Unauthorized(response);
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            return Ok(employee);
        }
    }
}   
