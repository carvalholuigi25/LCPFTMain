using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPFavThingsWebsite.Server.Context;
using LCPFavThingsWebsite.Shared.Models;

namespace LCPFavThingsWebsite.Server.Controllers
{
    [Route("api/[controller]", Name = "tvseries")]
    [ApiController]
    public class TVSeriesController : ControllerBase
    {
        private readonly DBContext _context;

        public TVSeriesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TVSeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TVSeries>>> GetTVSerie()
        {
          if (_context.TVSerie == null)
          {
              return NotFound();
          }
            return await _context.TVSerie.ToListAsync();
        }

        // GET: api/TVSeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TVSeries>> GetTVSeries(int? id)
        {
          if (_context.TVSerie == null)
          {
              return NotFound();
          }
            var tVSeries = await _context.TVSerie.FindAsync(id);

            if (tVSeries == null)
            {
                return NotFound();
            }

            return tVSeries;
        }

        // PUT: api/TVSeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTVSeries(int? id, TVSeries tVSeries)
        {
            if (id != tVSeries.TVSerieId)
            {
                return BadRequest();
            }

            _context.Entry(tVSeries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVSeriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TVSeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TVSeries>> PostTVSeries(TVSeries tVSeries)
        {
          if (_context.TVSerie == null)
          {
              return Problem("Entity set 'DBContext.TVSerie'  is null.");
          }
            _context.TVSerie.Add(tVSeries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTVSeries", new { id = tVSeries.TVSerieId }, tVSeries);
        }

        // DELETE: api/TVSeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTVSeries(int? id)
        {
            if (_context.TVSerie == null)
            {
                return NotFound();
            }
            var tVSeries = await _context.TVSerie.FindAsync(id);
            if (tVSeries == null)
            {
                return NotFound();
            }

            _context.TVSerie.Remove(tVSeries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TVSeriesExists(int? id)
        {
            return (_context.TVSerie?.Any(e => e.TVSerieId == id)).GetValueOrDefault();
        }
    }
}
