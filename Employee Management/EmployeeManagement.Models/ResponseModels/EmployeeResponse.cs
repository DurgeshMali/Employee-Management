using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Models.Enumerations;

namespace EmployeeManagement.Models.RequestModels
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public GenderEnum Gender { get; set; }
        public DateOnly DOB { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public string? Role { get; set; }
        public double Salary { get; set; }
        public string? Department { get; set; }
        public string? Designation { get; set; }
        public string? Manager { get; set; }

    }
}
