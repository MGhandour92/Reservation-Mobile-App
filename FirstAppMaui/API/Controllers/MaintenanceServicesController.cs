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
    public class MaintenanceServicesController : ControllerBase
    {
        private readonly MyDBContext _context;

        public MaintenanceServicesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/MaintenanceServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceService>>> GetMaintenanceServices()
        {
          if (_context.MaintenanceServices == null)
          {
              return NotFound();
          }
            return await _context.MaintenanceServices.ToListAsync();
        }

        // GET: api/MaintenanceServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceService>> GetMaintenanceService(int id)
        {
          if (_context.MaintenanceServices == null)
          {
              return NotFound();
          }
            var maintenanceService = await _context.MaintenanceServices.FindAsync(id);

            if (maintenanceService == null)
            {
                return NotFound();
            }

            return maintenanceService;
        }

        // PUT: api/MaintenanceServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceService(int id, MaintenanceService maintenanceService)
        {
            if (id != maintenanceService.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceServiceExists(id))
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

        // POST: api/MaintenanceServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaintenanceService>> PostMaintenanceService(MaintenanceService maintenanceService)
        {
          if (_context.MaintenanceServices == null)
          {
              return Problem("Entity set 'MyDBContext.MaintenanceServices'  is null.");
          }
            _context.MaintenanceServices.Add(maintenanceService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenanceService", new { id = maintenanceService.Id }, maintenanceService);
        }

        // DELETE: api/MaintenanceServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceService(int id)
        {
            if (_context.MaintenanceServices == null)
            {
                return NotFound();
            }
            var maintenanceService = await _context.MaintenanceServices.FindAsync(id);
            if (maintenanceService == null)
            {
                return NotFound();
            }

            _context.MaintenanceServices.Remove(maintenanceService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaintenanceServiceExists(int id)
        {
            return (_context.MaintenanceServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
