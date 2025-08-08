using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Models.RequestModels;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> AddEmployeeAsync(EmployeeRequest newEmployee)
        {
            var employee = new Employee
            {
                Name = newEmployee.Name,
                Email = newEmployee.Email,
                PhoneNo = newEmployee.PhoneNo,
                GenderId = (int)newEmployee.Gender,
                DOB = newEmployee.DOB
            };

            var created = await _employeeRepository.AddAsync(employee);
            return created.Id;
        }
    }
}
