using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> GetEmployeeByMailIdAsync(string emailId)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Email.ToLower() == emailId.ToLower());
            return employee;
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }
    }
}
