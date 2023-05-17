using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore // temporary in-memory data store
    {
        public List<CityDto> Cities { get; set; } // Cities property

        // static property that returns an instance CitiesDataStore
        // This is a singleton pattern network. It makes sure that we can keep on
        // working on the same store, as long as we don't restart the web server. 
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            // init dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestsDto>()
                    {
                        new PointOfInterestsDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "Big park"
                        },
                        new PointOfInterestsDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper"
                        },

                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with hands everywhere.",
                    PointsOfInterest = new List<PointOfInterestsDto>()
                    {
                        new PointOfInterestsDto()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A Gothic style cathedral",
                        },
                        new PointOfInterestsDto()
                        {
                            Id = 4,
                            Name = "Antwer Central Station",
                            Description = "Railway station with nice architecture"
                        },
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestsDto>()
                    {
                        new PointOfInterestsDto()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "Tower on the the Champ de Mars"
                        },
                        new PointOfInterestsDto()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum"
                        },
                    }
                }
            };

        }
    }
}
