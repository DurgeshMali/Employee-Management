using EmployeeManagement.Models.DBModels;

namespace EmployeeManagement.Models.RequestModels
{
    public class DesignationResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public LevelResponse? Level { get; set; }
    }
}
