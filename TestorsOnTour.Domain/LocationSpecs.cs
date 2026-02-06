using System;

namespace TestorsOnTour.Domain;

public class LocationSpecs
{
    public string Id { get; set; } = new Guid().ToString();
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Venue { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

}
