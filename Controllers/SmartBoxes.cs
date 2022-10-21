using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class SmartBoxes : Controller
    {
        private readonly ApplicationDbContext _context;

        public SmartBoxes(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SmartBoxes
        public async Task<IActionResult> Index()
        {
              return _context.smartBoxes != null ? 
                          View(await _context.smartBoxes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.smartBoxes'  is null.");
        }

        // GET: SmartBoxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.smartBoxes == null)
            {
                return NotFound();
            }

            var smartBox = await _context.smartBoxes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartBox == null)
            {
                return NotFound();
            }

            return View(smartBox);
        }

        // GET: SmartBoxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SmartBoxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image,DurataInNotti,Price,city,Country")] SmartBox smartBox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smartBox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smartBox);
        }

        // GET: SmartBoxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.smartBoxes == null)
            {
                return NotFound();
            }

            var smartBox = await _context.smartBoxes.FindAsync(id);
            if (smartBox == null)
            {
                return NotFound();
            }
            return View(smartBox);
        }

        // POST: SmartBoxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Image,DurataInNotti,Price,city,Country")] SmartBox smartBox)
        {
            if (id != smartBox.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smartBox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmartBoxExists(smartBox.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(smartBox);
        }

        // GET: SmartBoxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.smartBoxes == null)
            {
                return NotFound();
            }

            var smartBox = await _context.smartBoxes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartBox == null)
            {
                return NotFound();
            }

            return View(smartBox);
        }

        // POST: SmartBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.smartBoxes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.smartBoxes'  is null.");
            }
            var smartBox = await _context.smartBoxes.FindAsync(id);
            if (smartBox != null)
            {
                _context.smartBoxes.Remove(smartBox);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmartBoxExists(int id)
        {
          return (_context.smartBoxes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
