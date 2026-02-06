using System;
using TestorsOnTour.Domain;

namespace TestorsOnTour.Persistence;

public class DbInitializer
{
    public static async Task SeedData(TestorsOnTourDbContext context)
    {
        if(context.Hikes.Any())
        {
            return; // DB has been seeded
        }

        var hike1 = new Hike
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Grand Canyon South Rim Hike",
            Description = "A scenic hike along the South Rim of the Grand Canyon.",
            City = "Grand Canyon Village",
            Country = "USA",
            Venue = "Grand Canyon National Park",
            Latitude = 36.054445,
            Longitude = -112.140111,
            HikeDate = new DateTime(2024, 10, 15)
        };

        var hike2 = new Hike
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Grand Canyon Inner Canyon Hike",
            Description = "A challenging hike into the inner canyon of the Grand Canyon.",
            City = "Phantom Ranch",
            Country = "USA",
            Venue = "Grand Canyon National Park",
            Latitude = 36.106965,
            Longitude = -112.112997,
            HikeDate = new DateTime(2024, 10, 20)
        };        
        
        context.Hikes.Add(hike1);
        context.Hikes.Add(hike2);
        await context.SaveChangesAsync();
    }
}
