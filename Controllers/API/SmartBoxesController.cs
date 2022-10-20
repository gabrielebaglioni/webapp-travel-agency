using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SmartBoxesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SmartBoxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SmartBoxes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SmartBox>>> GetsmartBoxes()
        //{
        //  if (_context.smartBoxes == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.smartBoxes.ToListAsync();
        //}

        //get for search
        [HttpGet]
        public IActionResult GetsmartBoxes(string? name)
        {
            IQueryable<SmartBox> smartBoxes;

            if (name != null)
            {
                smartBoxes = _context.smartBoxes.Where(x => x.Title.ToLower().Contains(name.ToLower()));
            }
            else
            {
                smartBoxes = _context.smartBoxes;
            }

            return Ok(smartBoxes.ToList<SmartBox>());
        }

        // GET: api/SmartBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmartBox>> GetSmartBox(int id)
        {
          if (_context.smartBoxes == null)
          {
              return NotFound();
          }
            var smartBox = await _context.smartBoxes.FindAsync(id);

            if (smartBox == null)
            {
                return NotFound();
            }

            return smartBox;
        }

        // PUT: api/SmartBoxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartBox(int id, SmartBox smartBox)
        {
            if (id != smartBox.Id)
            {
                return BadRequest();
            }

            _context.Entry(smartBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartBoxExists(id))
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

        // POST: api/SmartBoxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmartBox>> PostSmartBox(SmartBox smartBox)
        {
          if (_context.smartBoxes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.smartBoxes'  is null.");
          }
            _context.smartBoxes.Add(smartBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartBox", new { id = smartBox.Id }, smartBox);
        }

        // DELETE: api/SmartBoxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartBox(int id)
        {
            if (_context.smartBoxes == null)
            {
                return NotFound();
            }
            var smartBox = await _context.smartBoxes.FindAsync(id);
            if (smartBox == null)
            {
                return NotFound();
            }

            _context.smartBoxes.Remove(smartBox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmartBoxExists(int id)
        {
            return (_context.smartBoxes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
