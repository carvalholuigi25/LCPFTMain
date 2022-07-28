using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPFavThingsWApi.Context;
using LCPFavThingsWApi.Models;
using bc = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using LCPFavThingsWApi.SecurityApi.JWT;
//using Microsoft.AspNetCore.Authorization;

namespace LCPFavThingsWApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    //[Authorize("Bearer")]
    public class UsersController : ControllerBase
    {
        private readonly DBContext _context;

        public UsersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int? id)
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            var users = await _context.User.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize("Bearer", Roles = Roles.ROLE_ACESSO_APIS)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int? id, Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            if(!string.IsNullOrEmpty(users.PasswordT))
            {
                users.PasswordT = bc.HashPassword(users.PasswordT);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize("Bearer", Roles = Roles.ROLE_ACESSO_APIS)]
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            if (_context.User == null)
            {
               return Problem("Entity set 'DBContext.Users'  is null.");
            }

            users.PasswordT = bc.HashPassword(users.PasswordT);

            _context.User.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [Authorize("Bearer", Roles = Roles.ROLE_ACESSO_APIS)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int? id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var users = await _context.User.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.User.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int? id)
        {
            return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
