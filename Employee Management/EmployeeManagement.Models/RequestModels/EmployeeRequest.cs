using EmployeeManagement.Models.DBModels;
using EmployeeManagement.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.RequestModels
{
    public class EmployeeRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "PhoneNo is required")]
        public string? PhoneNo { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female or Other.")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "DOB is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateOnly DOB { get; set; }
    }
}
