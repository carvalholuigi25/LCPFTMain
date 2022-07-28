using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPFavThingsWApi.Context;
using LCPFavThingsWApi.Models;

namespace LCPFavThingsWApi.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DBContext _context;

        public GamesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Games>>> GetGame()
        {
          if (_context.Game == null)
          {
              return NotFound();
          }
            return await _context.Game.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Games>> GetGames(int? id)
        {
          if (_context.Game == null)
          {
              return NotFound();
          }
            var games = await _context.Game.FindAsync(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGames(int? id, Games games)
        {
            if (id != games.GameId)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Games>> PostGames(Games games)
        {
          if (_context.Game == null)
          {
              return Problem("Entity set 'DBContext.Game'  is null.");
          }
            _context.Game.Add(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGames", new { id = games.GameId }, games);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGames(int? id)
        {
            if (_context.Game == null)
            {
                return NotFound();
            }
            var games = await _context.Game.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            _context.Game.Remove(games);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamesExists(int? id)
        {
            return (_context.Game?.Any(e => e.GameId == id)).GetValueOrDefault();
        }
    }
}
