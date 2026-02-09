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
        public string Id { get; set; }
    }

    public class Handler(TestorsOnTourDbContext context) : IRequestHandler<Query, Hike?>
    {
        public Task<Hike?> Handle(Query request, CancellationToken cancellationToken)
        {
            return context.Hikes.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);
        }
    }
}
