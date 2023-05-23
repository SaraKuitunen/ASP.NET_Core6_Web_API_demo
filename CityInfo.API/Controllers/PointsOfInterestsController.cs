using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest/")]
    [ApiController]
    public class PointsOfInterestsController : ControllerBase
    {
        [HttpGet] // attribute signifies that this action can be routed to when the HTTP method is GET
        public ActionResult<IEnumerable<PointOfInterestsDto>> GetPointsOfInterest(int cityId)

        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestsDto> GetPointOfInterest(
            int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest
                .FirstOrDefault(c => c.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestForCreationDto> CreatePointOfInterest(
            int cityId, // accept cityId parameter from the route
            PointOfInterestForCreationDto pointOfInterest) // to get the request body of the request message
                                                           // that will contain the pointofinterest data which 
                                                           // is deserialized to a PointOfInterestForCreationDto
                                                           // FromBody annotation is not needed because ApiController attribute is used
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            // temporary way to get id: get highest ID of all points and later add 1 to it
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                c => c.PointsOfInterest).Max(p => p.Id);

            // Map PointOfInterestForCreationDto to PointOfInterestDto, that is used by the data store
            var finalPointOfInterest = new PointOfInterestsDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name, // comes from request body
                Description = pointOfInterest.Description, // comes from request body
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            // return CreatedAtRouteResult
            return CreatedAtRoute("GetPointOfInterest", // routeName -> will be in response header
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id, // Ids as routeValues
                },
                finalPointOfInterest); // created object -> will be in response body
        }
    }
}
