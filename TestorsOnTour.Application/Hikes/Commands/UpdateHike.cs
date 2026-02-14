using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.Application.Hikes.Commands;

public class UpdateHike
{
    public class Command(string Id, Hike Hike) : IRequest
    {
        public string Id { get; } = Id;
        public Hike Hike { get; } = Hike;
    }

    public class Handler(TestorsOnTourDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public Task Handle(Command request, CancellationToken cancellationToken)
        {
            //context.Entry(request.Hike).State = EntityState.Modified;
            var hike = context.Hikes.Find(request.Id) ?? throw new KeyNotFoundException("Hike not found.");
            mapper.Map(request.Hike, hike);

            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
