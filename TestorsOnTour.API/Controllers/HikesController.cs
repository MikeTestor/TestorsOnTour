using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Application.Hikes.Commands;
using TestorsOnTour.Application.Hikes.Queries;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.API.Controllers
{
    public class HikesController() : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hike>>> GetHikes()
        {
            //return await context.Hikes.ToListAsync();
            return await Mediator.Send(new GetHikesList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hike>> GetHikeById(string id)
        {
            var hike = await Mediator.Send(new GetHike.Query { Id = id });
            return hike == null ? NotFound() : Ok(hike);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateHike(Hike hike)
        {
            // var hikeId = await Mediator.Send(new CreateHike.Command { Hike = hike });
            // return CreatedAtAction(nameof(GetHikeById), new { id = hikeId }, hike);

            return await Mediator.Send(new CreateHike.Command { Hike = hike });            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHike(string id, Hike hike)
        {
            if (id != hike.Id)
            {
                return BadRequest("Hike ID mismatch.");
            }

            await Mediator.Send(new UpdateHike.Command(id, hike));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHike(string id)
        {
            await Mediator.Send(new DeleteHike.Command { Id = id });
            return NoContent();
        }
    }
}
