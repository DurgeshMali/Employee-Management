using EmployeeManagement.Models.DBModels;

namespace EmployeeManagement.Models.RequestModels
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public GenderResponse? Gender { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime DateOfJoining { get; set; }
        public SalaryResponse? Salary   { get; set; }
        public DepartmentResponse? Department { get; set; }
        public DesignationResponse? Designation { get; set; }
        public EmployeeResponse? Manager { get; set; }

    }
}
