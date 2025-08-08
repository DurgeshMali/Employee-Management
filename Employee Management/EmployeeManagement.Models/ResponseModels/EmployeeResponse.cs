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
        public SalaryResponse? Salary   { get; set; }
        public DepartmentResponse? Department { get; set; }
        public DesignationResponse? Designation { get; set; }
        public EmployeeResponse? Manager { get; set; }

    }
}
