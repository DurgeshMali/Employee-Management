using EmployeeManagement.Models.RequestModels;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(EmployeeRequest employee);
    }
}
