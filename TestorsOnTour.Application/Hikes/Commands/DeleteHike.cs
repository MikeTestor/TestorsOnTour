using System;
using MediatR;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.Application.Hikes.Commands;

public class DeleteHike
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(TestorsOnTourDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var hike = await context.Hikes.FindAsync([request.Id], cancellationToken);
            if (hike == null)
            {
                throw new KeyNotFoundException("Hike not found.");
            }

            context.Hikes.Remove(hike);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
