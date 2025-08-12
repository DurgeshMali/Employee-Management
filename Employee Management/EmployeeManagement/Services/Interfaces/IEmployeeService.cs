using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Models.RequestModels;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(EmployeeRequest employee);
        //Task<EmployeeResponse> GetEmployeeByMailIdAsync(string employeeMailId);

        Task<string> EmployeeLogInAsync(EmployeeLoginRequest employeeLoginRequest);

        Task<EmployeeResponse> GetEmployeeById(int employeeId);
    }
}
