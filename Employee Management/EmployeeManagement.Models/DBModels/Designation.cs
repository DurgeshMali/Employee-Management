using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models.DBModels;

public partial class Designation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? LevelId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Level? Level { get; set; }
}
