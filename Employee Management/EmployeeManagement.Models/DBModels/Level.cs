using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models.DBModels;

public partial class Level
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Designation> Designations { get; set; } = new List<Designation>();
}
