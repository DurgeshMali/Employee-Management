namespace EmployeeManagement.Models.RequestModels
{
    public class SalaryResponse
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public double Basic {  get; set; }
        public double Allowance { get; set; }
        public double NetSalary {  get; set; }
    }
}
