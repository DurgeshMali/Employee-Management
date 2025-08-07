using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models.DBModels;

public partial class Salary
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Basic { get; set; }

    public decimal? Allowance { get; set; }

    public decimal? NetSalary { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
