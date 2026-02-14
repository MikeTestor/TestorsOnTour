using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.Application.Hikes.Queries;

public class GetHike
{
    public class Query : IRequest<Hike>
    {
        public required string Id { get; set; }
    }

    public class Handler(TestorsOnTourDbContext context) : IRequestHandler<Query, Hike?>
    {
        public async Task<Hike?> Handle(Query request, CancellationToken cancellationToken)
        {
            // Three ways to get a single item by id using EF Core:
            // return context.Hikes.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);
            //return context.Hikes.FindAsync([request.Id], cancellationToken).AsTask();
            return await context.Hikes.FindAsync([request.Id], cancellationToken);
        }
    }
}
