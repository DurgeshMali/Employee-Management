using EmployeeManagement.Exceptions;
using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Models.Enumerations;
using EmployeeManagement.Models.RequestModels;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher<Employee> _passwordHasher;

        public EmployeeService(IEmployeeRepository employeeRepository, IPasswordHasher<Employee> passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _passwordHasher = passwordHasher;
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
                Role = null,
                Salary = 0.00,
                Department = null,
                Designation = null,
                Manager = null
            };
        }
    }
}
