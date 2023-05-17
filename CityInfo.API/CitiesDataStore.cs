using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore // temporary in-memory data store
    {
        public List<CityDto> Cities { get; set; } // Cities property

        // static property that returns an instance CitiesDataStore
        //  This is a singleton pattern network. It makes sure that we can keep on
        //  working on the same store, as long as we don't restart the web server. 
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore() // construct??
        {
            // init dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with hands everywhere."
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower."
                }
            };

        }
    }
}
