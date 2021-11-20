using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreWebAPI.Entities;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly MeetupContext _context;

        public MeetupController(MeetupContext context)
        {
            _context = context;
        }

        // GET: api/Meetup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meetup>>> GetMeetups()
        {
            return await _context.Meetups.ToListAsync();
        }

        // GET: api/Meetup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meetup>> GetMeetup(int id)
        {
            var meetup = await _context.Meetups.FindAsync(id);

            if (meetup == null)
            {
                return NotFound();
            }

            return meetup;
        }

        // PUT: api/Meetup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetup(int id, Meetup meetup)
        {
            if (id != meetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(meetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetupExists(id))
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

        // POST: api/Meetup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meetup>> PostMeetup(Meetup meetup)
        {
            _context.Meetups.Add(meetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetup", new { id = meetup.Id }, meetup);
        }

        // DELETE: api/Meetup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetup(int id)
        {
            var meetup = await _context.Meetups.FindAsync(id);
            if (meetup == null)
            {
                return NotFound();
            }

            _context.Meetups.Remove(meetup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetupExists(int id)
        {
            return _context.Meetups.Any(e => e.Id == id);
        }
    }
}
