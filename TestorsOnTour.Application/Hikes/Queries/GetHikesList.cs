using System;
using MediatR;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public async Task<List<Hike>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Hikes.ToListAsync(cancellationToken);
        }
    }
}
