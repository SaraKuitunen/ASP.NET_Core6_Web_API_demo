namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        // To avoid null reference issues, init collection to empty collection
        public ICollection<PointOfInterestsDto> PointsOfInterest { get; set; }
            = new List<PointOfInterestsDto>();
    }
}
