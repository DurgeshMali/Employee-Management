using EmployeeManagement.Exceptions;
using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Models.Enumerations;
using EmployeeManagement.Models.RequestModels;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher<Employee> _passwordHasher;
        private readonly IConfiguration _configuration;

        public EmployeeService(IEmployeeRepository employeeRepository, IPasswordHasher<Employee> passwordHasher, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }
        public async Task<int> AddEmployeeAsync(EmployeeRequest newEmployee)
        {
            if(await _employeeRepository.GetEmployeeByMailIdAsync(newEmployee.Email) != null)
            {
                throw new NotFoundException("EmailId already exists.");
            }

            var employee = new Employee
            {
                Name = newEmployee.Name,
                Email = newEmployee.Email,
                PhoneNo = newEmployee.PhoneNo,
                GenderId = (int)newEmployee.Gender,
                DOB = newEmployee.DOB
            };
            employee.Password = _passwordHasher.HashPassword(employee, newEmployee.Password);

            var created = await _employeeRepository.AddAsync(employee);
            return created.Id;
        }

        public async Task<string?> EmployeeLogInAsync(EmployeeLoginRequest employeeLoginRequest)
        {
            var employee = await _employeeRepository.GetEmployeeByMailIdAsync(employeeLoginRequest.Email);
            if (employee == null || _passwordHasher.VerifyHashedPassword(employee, employee.Password, employeeLoginRequest.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, employeeLoginRequest.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new NotFoundException("JWT Secret is not configured.");
            }
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<EmployeeResponse?> GetEmployeeByMailIdAsync(string mailId)
        //{
        //    var employee = await _employeeRepository.GetEmployeeByMailIdAsync(mailId);
        //    if (employee == null) return null;

        //    return MapToEmployeeResponse(employee);
        //}

        public async Task<EmployeeResponse?> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                throw new NotFoundException("Employee does not exist with Id:" + id);
            }

            return MapToEmployeeResponse(employee);
        }

        private EmployeeResponse MapToEmployeeResponse(Employee employee)
        {
            return new EmployeeResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                PhoneNo = employee.PhoneNo,
                Gender = (GenderEnum)employee.GenderId,
                DOB = employee.DOB,
                DateOfJoining = employee.DateOfJoining ?? default,
                Role = (RoleEnum)employee.RoleId,
                Salary = 0.00,
                Department = null,
                Designation = null,
                Manager = null
            };
        }
    }
}
