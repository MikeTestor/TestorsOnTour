using System;
using MediatR;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.Application.Hikes.Commands;

public class CreateHike
{
    public class Command : IRequest<string>
    {
        public required Hike Hike { get; set; }
    }

    public class Handler(TestorsOnTourDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var hike = request.Hike;
            hike.Id = Guid.NewGuid().ToString();

            context.Hikes.Add(hike);
            await context.SaveChangesAsync(cancellationToken);

            return hike.Id;
        }
    }
}
