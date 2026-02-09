using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.Application.Hikes.Queries;

public class GetHikesList
{
    public class Query : IRequest<List<Hike>>
    {
    }

    public class Handler (TestorsOnTourDbContext context) : IRequestHandler<Query, List<Hike>>
    {
        public Task<List<Hike>> Handle(Query request, CancellationToken cancellationToken)
        {
            return context.Hikes.ToListAsync(cancellationToken);
        }
    }
}
