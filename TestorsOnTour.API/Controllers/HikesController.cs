using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestorsOnTour.Domain;
using TestorsOnTour.Persistence;

namespace TestorsOnTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HikeController : ControllerBase
    {
        private readonly TestorsOnTourDbContext _context;

        public HikeController(TestorsOnTourDbContext context)
        {            
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hike>>> GetHikes()
        {
            return await _context.Hikes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hike>> GetHikeById(string id)
        {
            var hike = await _context.Hikes.FirstOrDefaultAsync(h => h.Id == id);
            if (hike == null)
            {
                return NotFound();
            }
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
            
            _context.Hikes.Add(hike);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHikeById), new { id = hike.Id }, hike);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHike(string id, Hike hike)
        {
            if (id != hike.Id)
            {
                return BadRequest();
            }

            _context.Entry(hike).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHike(string id)
        {
            var hike = await _context.Hikes.FirstOrDefaultAsync(h => h.Id == id);
            if (hike == null)
            {
                return NotFound();
            }

            _context.Hikes.Remove(hike);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
