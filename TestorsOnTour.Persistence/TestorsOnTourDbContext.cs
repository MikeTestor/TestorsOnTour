using System;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Domain;

namespace TestorsOnTour.Persistence;

public class TestorsOnTourDbContext (DbContextOptions<TestorsOnTourDbContext> options) : DbContext(options)
{
    public DbSet<Hike> Hikes { get; set; }  
}
