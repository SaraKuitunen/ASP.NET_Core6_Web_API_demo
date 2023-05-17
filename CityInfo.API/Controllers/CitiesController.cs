using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController] // applying ApiController attribute configures controller with features helping in building API
    [Route("api/[controller]")] // Route attribute can be used to set base address -> api/cities because the controller name starts with "Cities" 
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities() // return type of the action is a collection of CityDtos
        {
            // no NotFound here, because even an empty collection is a valid response body
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            // find city
            var cityToReturn = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            // Ok returns an OK result, which implements IActionResult,
            // which defines a contract that represents the result of an action method
            return Ok(cityToReturn);
        }
    }
}