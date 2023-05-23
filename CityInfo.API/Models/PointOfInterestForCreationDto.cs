using System.ComponentModel.DataAnnotations;

namespace CityInfo.API
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "You need to provide a name value.")] // Data Annotation: input validation rule
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
