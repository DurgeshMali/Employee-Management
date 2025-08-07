using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models.DBModels;

public partial class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
