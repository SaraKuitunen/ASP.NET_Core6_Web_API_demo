using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController] // applying ApiController attribute configures controller with features helping in building API
    [Route("api/[controller]")] // Route attribute can be used to set base address -> api/cities because the controller name starts with "Cities" 
    public class CitiesController : ControllerBase
    {
        [HttpGet] // specify route
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<object>
                {
                    new { id = 1, Name = "New York City"},
                    new { id = 2, Name = "Antwerp" }
                });
        }
    }
}
