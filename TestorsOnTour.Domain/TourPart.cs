using System;

namespace TestorsOnTour.Domain;

public class TourPart
{
    public string Id { get; set; } = new Guid().ToString();
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public LocationSpecs? Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
