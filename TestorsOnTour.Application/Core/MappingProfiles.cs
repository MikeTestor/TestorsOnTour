using System;
using AutoMapper;
using TestorsOnTour.Domain;

namespace TestorsOnTour.Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    {
        CreateMap<Hike, Hike>();
    }

}
