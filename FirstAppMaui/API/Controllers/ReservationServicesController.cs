using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using Common.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationServicesController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ReservationServicesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/ReservationServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationService>>> GetReservationServices()
        {
          if (_context.ReservationServices == null)
          {
              return NotFound();
          }
            return await _context.ReservationServices.ToListAsync();
        }

        // GET: api/ReservationServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationService>> GetReservationService(int id)
        {
          if (_context.ReservationServices == null)
          {
              return NotFound();
          }
            var reservationService = await _context.ReservationServices.FindAsync(id);

            if (reservationService == null)
            {
                return NotFound();
            }

            return reservationService;
        }

        // PUT: api/ReservationServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationService(int id, ReservationService reservationService)
        {
            if (id != reservationService.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservationService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationServiceExists(id))
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

        // POST: api/ReservationServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationService>> PostReservationService(ReservationService reservationService)
        {
          if (_context.ReservationServices == null)
          {
              return Problem("Entity set 'MyDBContext.ReservationServices'  is null.");
          }
            _context.ReservationServices.Add(reservationService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationService", new { id = reservationService.Id }, reservationService);
        }

        // DELETE: api/ReservationServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationService(int id)
        {
            if (_context.ReservationServices == null)
            {
                return NotFound();
            }
            var reservationService = await _context.ReservationServices.FindAsync(id);
            if (reservationService == null)
            {
                return NotFound();
            }

            _context.ReservationServices.Remove(reservationService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationServiceExists(int id)
        {
            return (_context.ReservationServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
