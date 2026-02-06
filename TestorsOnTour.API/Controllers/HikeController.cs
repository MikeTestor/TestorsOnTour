using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HikesController (TestorsOnTourDbContext context) : ControllerBase
    {        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hike>>> GetHikes()
        {
            return await context.Hikes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hike>> GetHikeById(string id)
        {
            var hike = await context.Hikes.FirstOrDefaultAsync(h => h.Id == id);
            
            if (hike == null) return NotFound();
            
            return hike;
        }

        [HttpPost]
        public async Task<ActionResult<Hike>> CreateHike(Hike hike)
        {
            hike.Id = Guid.NewGuid().ToString();

            if (hike == null)
            {
                return BadRequest();
            }
            
            context.Hikes.Add(hike);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHikeById), new { id = hike.Id }, hike);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHike(string id, Hike hike)
        {
            if (id != hike.Id)
            {
                return BadRequest();
            }

            context.Entry(hike).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHike(string id)
        {
            var hike = await context.Hikes.FirstOrDefaultAsync(h => h.Id == id);
            if (hike == null)
            {
                return NotFound();
            }

            context.Hikes.Remove(hike);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
