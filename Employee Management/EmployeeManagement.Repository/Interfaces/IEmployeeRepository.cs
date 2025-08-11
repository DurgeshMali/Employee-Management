using EmployeeManagement.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        //Task<IEnumerable<Employee>> GetAllAsync();
        //Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);

        Task<Employee> GetEmployeeByMailIdAsync(string mailId);

        Task<Employee> GetEmployeeById(int id);
    }
}
