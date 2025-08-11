using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models.DBModels;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public int? GenderId { get; set; }

    public DateOnly DOB { get; set; }

    public string Password { get; set; } = null!;

    public DateOnly? DateOfJoining { get; set; }

    public int? RoleId { get; set; }

    public int? DepartmentId { get; set; }

    public int? DesignationId { get; set; }

    public int? SalaryId { get; set; }

    public int? ManagerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Designation? Designation { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Salary? Salary { get; set; }
}
