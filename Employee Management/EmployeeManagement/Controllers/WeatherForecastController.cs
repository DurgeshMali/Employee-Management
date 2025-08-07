using EmployeeManagement.Models.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Gender> Get()
        {
            using (var context = new EmployeeDbContext())
            {
                return (IEnumerable<Gender>)context.Genders.Select(Gender => Gender.Name);
            }
        }
    }
}
